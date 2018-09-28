using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WelfareDenmarkMVC.Models;

namespace WelfareDenmarkMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Om os";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Vores kontaktinfo";

            return View();
        }
        public IActionResult RemoveDementia()
        {
            ViewData["Message"] = "Hvordan du slipper af med demens";

            return View();
        }
        public IActionResult LogInSupport()
        {
            ViewData["Message"] = "Log in Support";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
