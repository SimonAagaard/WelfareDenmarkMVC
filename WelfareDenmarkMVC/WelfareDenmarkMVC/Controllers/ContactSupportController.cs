using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmarkMVC.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WelfareDenmarkMVC.Controllers
{
    public class ContactSupportController : Controller
    {
        // GET: /<controller>/
        public IActionResult LogInSupport()
        {
            ViewData["Message"] = "LogInSupport";

            return View();
        }
        public IActionResult FAQ()
        {
            ViewData["Message"] = "FAQ";

            return View();
        }
        public IActionResult Security()
        {
            ViewData["Message"] = "Security";

            return View();
        }
        public IActionResult Payment()
        {
            ViewData["Message"] = "Payment";

            return View();
        }
        public IActionResult Donations()
        {
            ViewData["Message"] = "Donations";

            return View();
        }

        public IActionResult ForgotPassword()
        {
            ViewData["Message"] = "ForgotYouPassword";
            return View();
        }
        public IActionResult KeyTerms()
        {
            ViewData["Message"] = "KeyTerms";

            return View();
        }
    }
}
