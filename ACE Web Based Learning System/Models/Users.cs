using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string UserRole { get; set; }
        public int UserContent { get; set; }

        public virtual UserContent UserContent1 { get; set; }
    }
}