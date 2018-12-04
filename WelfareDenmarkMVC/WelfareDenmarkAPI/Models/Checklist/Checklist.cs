using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkAPI.Models
{
    
    public class Checklist
    {
        public string ChecklistItem { get; set; }

        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
