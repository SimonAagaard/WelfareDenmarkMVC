using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmarkMVC.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WelfareDenmarkMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult LogInSupport()
        {
            return View();
        }
    }
}
