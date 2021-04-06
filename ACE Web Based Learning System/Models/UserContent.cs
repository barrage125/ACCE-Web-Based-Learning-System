using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class UserContent
    {
        public string ID { get; set; }
        [Required]
        public int UserID { get; set; }
        public string Gender { get; set; }
        public string Pronoun { get; set; }
        public Nullable<int> Age { get; set; }
       
        public string Color { get; set; } = "Grey";
        public string Status { get; set; }
       
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}