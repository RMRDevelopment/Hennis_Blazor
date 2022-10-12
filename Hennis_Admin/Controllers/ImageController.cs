using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Hennis_Admin.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ImageController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("[action]")]
        [Route("api/Image/Save")]
        public void Save(IList<IFormFile> uploadFiles)
        {
            try
            {
                foreach (var file in uploadFiles)
                {
                    if (uploadFiles != null)
                    {
                        string targetPath = _env.ContentRootPath + "\\Images";
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');

                        // Create directory if doesn't exist
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        // Name for image
                        fileName = targetPath + $@"\{fileName}";

                        if (!System.IO.File.Exists(fileName))
                        {
                            // upload image
                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                            Response.StatusCode = 200;
                        }
                    }
                    else
                    {
                        Response.StatusCode = 204;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
            }
        }

    }
}