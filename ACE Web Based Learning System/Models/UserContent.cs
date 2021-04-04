using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class UserContent
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Gender { get; set; }
        public string Pronoun { get; set; }
        public Nullable<int> Age { get; set; }
        [Required]
        public string Color { get; set; } = "Grey";
        public string Status { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}