using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WelfareDenmarkMVC.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Location()
        {
            return View();
        }

        public IActionResult Location2()
        {
            return View();
        }
    }
}