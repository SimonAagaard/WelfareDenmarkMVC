using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkAPI.Models;

namespace WelfareDenmarkAPI.Models
{
    public class ChecklistContext : DbContext
    {
        public ChecklistContext(DbContextOptions<ChecklistContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //This is for overriding with specific wishes
            
        }

        public DbSet<Checklist> Checklists { get; set; }
    }
}
