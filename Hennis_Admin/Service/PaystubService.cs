using Hennis_Admin.Service.IService;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_Models.Dto;
using Hennis_Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using PdfSharp.Pdf.IO;
//using PdfSharp.Pdf;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Graphics.Operations.General;
using UglyToad.PdfPig.Writer;
//using PdfSharp.Pdf.Content;
//using PdfSharp.Pdf.Content.Objects;

namespace Hennis_Admin.Service
{
    public class PaystubService : IPaystubService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPaystubRepository _paystubRepository;

        public PaystubService(IWebHostEnvironment env, ApplicationDbContext context, IUserRepository userRepository, IPaystubRepository paystubRepository)
        {
            _env = env;
            _context = context;
            _userRepository = userRepository;
            _paystubRepository = paystubRepository;
        }
        public async Task<string> ProcessPdf(PaystubModel model)
        {
            string targetPath = _env.ContentRootPath + Hennis_Common.SD.TEMP_FILE_PATH;
            string filename = model.FileName;
            string firstname = "", lastname = "";
            StringBuilder errorList = new StringBuilder();
            try
            {
                // Name which is used to save the image
                filename = targetPath + $@"\{filename}";
                //var t = File.Open("C:/code/Hennis/Hennis_Admin/temp/" + model.FileName, FileMode.Open);
                if (System.IO.File.Exists(filename))
                {
                    using (var pdf = UglyToad.PdfPig.PdfDocument.Open(filename))
                    {
                        int pageNumber = 1;
                        foreach (var page in pdf.GetPages())
                        {
                            var text = ContentOrderTextExtractor.GetText(page);

                            var split = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            var name = split[4];

                            var nameSplit =  name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                            try
                            {
                                firstname = nameSplit[0] + " " + nameSplit[1];
                                lastname = nameSplit[2];

                            }
                            catch (Exception ex)
                            {
                                lastname = name;
                                firstname = "";
                                errorList.Append($"<li>Error Parsing: {name}</li>");
                            }
                            
                            var user = await _userRepository.GetUserByNameAndLocation(firstname, lastname,model.Location);

                            if (user == null)
                            {
                                errorList.Append($"<li>Not Found: {firstname} {lastname}</li>");
                            }
                            else
                            {
                                if (await _paystubRepository.PaystubExistsForEmployee(user.Id, model.PayDate))
                                {
                                    // skip because already exists
                                }
                                else
                                {
                                    // create paystub for employee.
                                    MemoryStream ms = new MemoryStream();
                                    var reader = new PdfReader(filename);
                                    var doc = new Document(reader.GetPageSizeWithRotation(pageNumber));
                                    var pdfCopy = new PdfCopy(doc, ms);
                                    doc.Open();
                                    var newP = pdfCopy.GetImportedPage(reader, pageNumber);
                                    pdfCopy.AddPage(newP);
                                    doc.Close();
                                    var arr = ms.ToArray();

                                    var result = await _paystubRepository.Create(new PaystubModel
                                    {
                                        Stream = arr,
                                        FileName = $"{firstname}_{lastname}_{model.PayDate.ToShortDateString().Replace("/","")}",
                                        PayDate = model.PayDate,
                                        Location = model.Location,
                                        Type = "application/pdf",
                                        UserId = user.Id
                                    });

                                    if (result.Id == 0)
                                    {
                                        errorList.Append($"<li>File failed to create: {firstname} - {lastname}</li>");
                                    }

                                    
                                }
                            }

                            pageNumber++;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                errorList.Append("<li>Fatal Error Occurred</li>");
                throw;
            }



            return errorList.ToString(); ;
        }

      
    }
}
