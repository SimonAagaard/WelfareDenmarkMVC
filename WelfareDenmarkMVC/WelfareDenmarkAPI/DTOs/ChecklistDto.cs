using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WelfareDenmarkAPI.DTOs
{
    public class ChecklistDto
    {
        public string ChecklistItem { get; set; }

        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
