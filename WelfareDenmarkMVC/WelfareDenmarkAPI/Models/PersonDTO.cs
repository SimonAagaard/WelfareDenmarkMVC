using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkAPI.Models
{
    public class PersonDTO
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
