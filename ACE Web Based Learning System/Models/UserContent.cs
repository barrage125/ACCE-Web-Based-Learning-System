using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class UserContent
    {
        public UserContent()
        {
            this.Users = new HashSet<Users>();
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Gender { get; set; }
        public string Pronoun { get; set; }
        public Nullable<int> Age { get; set; }
        public string Color { get; set; }
        public string StatusMessage { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}