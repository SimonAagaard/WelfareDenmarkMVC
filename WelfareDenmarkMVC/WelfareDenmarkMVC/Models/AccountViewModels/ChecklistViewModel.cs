using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.AccountViewModels
{
    public class ChecklistViewModel
    {
        public string ChecklistItem { get; set; }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

    }
}
