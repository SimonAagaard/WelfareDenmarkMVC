using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.Extensions.Options;

namespace WelfareDenmarkMVC.Models.FileLogger
{
    public static class MyFileLoggerMiddlewareExtension
    {
        public static IApplicationBuilder UseMyFileLogger(this IApplicationBuilder app, MyFileLoggerOptions options)
        {
            return app.UseMiddleware<MyFileLoggerMiddleware>(Options.Create(options));
        }
    }
}
