using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models
{
    [Table ("ContactList")]
    public class ContactListViewModel
    {
        [Key]
        public string ContactID { get; set; }

        [DisplayName("Navn")]
        [StringLength(100)]
        public string FullName { get; set; }

        [DisplayName("Telefon")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }
    }
}
