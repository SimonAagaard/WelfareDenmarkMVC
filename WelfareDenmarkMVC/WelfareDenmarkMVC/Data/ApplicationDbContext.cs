using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkMVC.Models;
using WelfareDenmarkMVC.Models.AccountViewModels;
using WelfareDenmarkMVC.Models.ManageViewModels;

namespace WelfareDenmarkMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<WelfareDenmarkMVC.Models.AccountViewModels.ChecklistViewModel> ChecklistViewModel { get; set; }

		public DbSet<ContactListViewModel> Contacts { get; set; }

        public DbSet<GalleryImageViewModel> GalleryImage { get; set; }

    }
}
