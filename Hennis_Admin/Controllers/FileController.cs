using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Hennis_Business.Repository.Interface;

namespace Hennis_Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IFileRepository _fileRepository;

        public FileController(IWebHostEnvironment env, IFileRepository fileRepository)
        {
            _env = env;
            _fileRepository = fileRepository;
        }

        [HttpPost("[action]")]
        public void Save(IList<IFormFile> UploadFiles)
        {
            long size = 0;
            try
            {
                string targetPath = _env.ContentRootPath + "\\" + Hennis_Common.SD.TEMP_FILE_PATH;

                // Create a new directory, if it does not exists
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                foreach (var file in UploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = targetPath + $@"\{fileName}";
                    size += (int)file.Length;
                    if (!System.IO.File.Exists(fileName))
                    {
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
            }
        }

        [HttpPost("[action]")]
        public void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                string targetPath = _env.ContentRootPath + "\\" + Hennis_Common.SD.TEMP_FILE_PATH;
                var filename = targetPath + $@"\{UploadFiles[0].FileName}";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }

        [HttpGet("[action]")]
        public async Task<FileStreamResult> DownloadFile(string guid)
        {
            var file = await _fileRepository.GetBinaryFile(Guid.Parse(guid));
            MemoryStream ms = new MemoryStream(file.Bytes);
            return new FileStreamResult(ms, file.FileExtension);
        }
    }
}
