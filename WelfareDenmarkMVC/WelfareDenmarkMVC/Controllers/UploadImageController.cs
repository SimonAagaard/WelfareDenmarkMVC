using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WelfareDenmarkMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class UploadImageController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public UploadImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IList<IFormFile> files)
        {
            foreach (IFormFile item in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                filename = this.EnsureFilename(filename);
                using (FileStream filestream = System.IO.File.Create(this.GetPath(filename)))
                {

                }
            }
            return this.Content("dejligt bedstefar");
        }

        private string GetPath(string filename)
        {
            string path = _hostingEnvironment.WebRootPath + "\\upload\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + filename;

        }

        private string EnsureFilename(string filename)
        {
            if (filename.Contains("\\"))
            {
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            return filename;
        }
    }
}