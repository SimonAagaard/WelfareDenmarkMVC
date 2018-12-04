using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.AccountViewModels
{
    [Table("Checklists")]
    public class ChecklistViewModel
    {
        [DisplayName("Huskeliste indlæg")]
        public string ChecklistItem { get; set; }

        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        

    }
}
