using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WelfareDenmarkMVC.Models
{
    public class MyFileLoggerOptions
    {
        public string FileName { get; set; }

        public delegate Task RequestDelegate(HttpContext context);


    }
}
