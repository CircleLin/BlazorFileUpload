using BlazorFileUpload.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFileUpload.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public UploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public  IActionResult PostAsync(UploadedFile uploadedFile)
        {
            try
            {
                var path = $"{env.WebRootPath}\\{uploadedFile.FileName}";               
                var fs = System.IO.File.Create(path);
                fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
                fs.Close();

                return Ok();
            }
            catch
            {
                return BadRequest("Save File Failed");
            }
        }
    }
}
