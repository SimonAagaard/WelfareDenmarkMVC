using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkMVC.Models.AccountViewModels
{
    [Table("Images")]
    public class GalleryImageViewModel
    {
            
            [DisplayName("Billede")]
            [Key]
            public byte[] Image { get; set; }

            //[Key]
            //public int Id { get; set; }
        }
}
