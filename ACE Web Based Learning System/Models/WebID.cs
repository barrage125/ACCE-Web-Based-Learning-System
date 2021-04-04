using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class WebID
    {
        public string ID { get; set; }
        public string password { get; set; }
        public int USER_ID { get; set; }
        public virtual User user { get; set; }
    }
}