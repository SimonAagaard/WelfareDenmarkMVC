using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkAPI.Entities
{
    public class Person
    {
       
        [EmailAddress]
        public string Email { get; set; }
    }
}
