using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Enrollment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }
       
        public string SectionID { get; set; }
        
        public int UserID { get; set; }
        
        public string EnrollmentID
        {
            get { return SectionID + "," + UserID; }

        }
       
        public virtual Section Section { get; set; }

       
        public virtual User User { get; set; }
       
    }
}