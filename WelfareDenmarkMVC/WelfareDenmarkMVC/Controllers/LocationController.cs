using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WelfareDenmarkMVC.Controllers
{
    public class LocationController : Controller
    {
        [Route("[controller]/[action]")]
        public IActionResult Location()
        {
            return View();
        }
    }
}