using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Credential
    {

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}