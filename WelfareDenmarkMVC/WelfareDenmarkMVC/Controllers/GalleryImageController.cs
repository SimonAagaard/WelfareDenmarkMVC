using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models.AccountViewModels;


namespace WelfareDenmarkMVC.Controllers
{
    public class GalleryImageController : Controller
    {

        private readonly ApplicationDbContext _context; 

       public GalleryImageController(ApplicationDbContext context)

           {
            _context = context;             
           }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddImage()
        //{
        //    return View();
        //}

        public async Task<IActionResult> UploadImage(GalleryImageViewModel galleryImageViewModel, IFormFile imageToBeUploaded)
        {
           
            if (!ModelState.IsValid)
            {
                return View(galleryImageViewModel);
            }

            if (imageToBeUploaded != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageToBeUploaded.CopyToAsync(memoryStream);
                    var imageToBeUploadedByteArray = memoryStream.ToArray();
                    galleryImageViewModel.Image = imageToBeUploadedByteArray;
                }
            }

            _context.GalleryImage.Add(galleryImageViewModel);
            await _context.SaveChangesAsync();
                        return View();
        }

    }
}
