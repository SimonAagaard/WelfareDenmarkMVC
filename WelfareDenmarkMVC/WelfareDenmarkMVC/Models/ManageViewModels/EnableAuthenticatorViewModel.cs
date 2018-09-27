using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WelfareDenmarkMVC.Models.ManageViewModels
{
    public class EnableAuthenticatorViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "Adgangskoden skal være minumum {2} karakterer langt.", MinimumLength = 7)]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string Code { get; set; }

        [BindNever]
        public string SharedKey { get; set; }

        [BindNever]
        public string AuthenticatorUri { get; set; }
    }
}
