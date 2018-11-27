using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkAPI.Models;

namespace WelfareDenmarkAPI.Models
{
    public class PersonDS : DbContext
    {
        public PersonDS(DbContextOptions<PersonDS> options) : base(options)
        {

        }
        public List<PersonDTO> Persons { get; set; }
        public DbSet<WelfareDenmarkAPI.Models.PersonDTO> PersonDTO { get; set; }
    }
}
