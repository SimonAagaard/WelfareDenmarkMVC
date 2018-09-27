using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Adgangskoden skal være minimum {2} karakterer langt.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "De 2 indtastede adgangskoder stemmer ikke overens.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
