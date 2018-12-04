using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models;
using WelfareDenmarkMVC.Services;
using WelfareDenmarkMVC.Views;

namespace WelfareDenmarkMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. IKKE SKRIV CONNECTION STRING HER! Brug DefaultConnection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ProxyAPI>();

            services.AddIdentity<ApplicationUser, IdentityRole>(o =>
            {

                //Password
                o.Password.RequireDigit = true;
                o.Password.RequireUppercase = true;
                o.Password.RequiredLength = 7;
                o.Password.RequireNonAlphanumeric = false;

                //Lockout settings
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                o.Lockout.MaxFailedAccessAttempts = 5;
                o.Lockout.AllowedForNewUsers = true;

                //User settings
                o.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/error/404";
                    await next();
                }
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
