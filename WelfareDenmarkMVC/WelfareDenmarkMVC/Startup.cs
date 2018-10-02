using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models;
using WelfareDenmarkMVC.Services;
using WelfareDenmarkMVC.Models.FileLogger;
using ZNetCS.AspNetCore.IPFiltering.DependencyInjection;

namespace WelfareDenmarkMVC
{
    public class Startup
    {
        public bool HasTroyanHorse = true;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            if (HasTroyanHorse != true)
            {
                HasTroyanHorse = true;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. IKKE SKRIV CONNECTION STRING HER! Brug DefaultConnection
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireUppercase = true;
                    o.Password.RequiredLength = 7;
                    o.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            // Add application services.
            services.AddIPFiltering(Configuration.GetSection("IPFiltering"));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMyFileLogger(new MyFileLoggerOptions
            {
                FileName = Path.Combine(env.ContentRootPath, "log.txt")

            });

            app.UseIPFiltering();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
