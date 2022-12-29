using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Hennis_Business.Repository.Interface;

namespace ImageUpload.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnv;
        private readonly IFileRepository _fileRepository;

        public ImageController(IWebHostEnvironment env, IFileRepository fileRepository)
        {
            this.hostingEnv = env;
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("Test")]
        public void Test()
        {
            Response.StatusCode = 200;
        }

        [HttpPost]
        [Route("Save")]
        public void Save(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        string targetPath = hostingEnv.ContentRootPath + "\\wwwroot\\Images";
                        string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        // Create a new directory, if it does not exists
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        // Name which is used to save the image
                        filename = targetPath + $@"\{filename}";

                        if (!System.IO.File.Exists(filename))
                        {
                            // Upload a image, if the same file name does not exist in the directory
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }

                            using (MemoryStream ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                // save to database
                                _fileRepository.Create(new Hennis_DAL.DbEntities.BinaryFile
                                {
                                    FileName = file.FileName,
                                    FileExtension = file.FileName.Substring(file.FileName.IndexOf(".")),
                                    Bytes = ms.ToArray(),
                                    Guid = Guid.NewGuid()
                                    

                                });
                            }

                            Response.StatusCode = 200;
                        }
                        else
                        {
                            Response.StatusCode = 204;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}