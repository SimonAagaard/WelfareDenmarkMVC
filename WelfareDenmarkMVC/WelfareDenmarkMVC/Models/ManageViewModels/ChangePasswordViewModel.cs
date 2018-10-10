using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nuværende kodeord")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Adgangskoden skal være minimum {2} karakterer langt.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Display(Name = "Nyt kodeord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekræft nyt kodeord")]
        [Compare("NewPassword", ErrorMessage = "De indtastede adgangskoder stemmer ikke overens.")] 
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
