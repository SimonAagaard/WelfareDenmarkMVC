using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Adgangskoden skal være minimum {2} karakterer langt.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "De indtastede adgangskoder stemmer ike overens.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
