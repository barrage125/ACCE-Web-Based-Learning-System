using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class CourseContent
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        
        //JSON data containing the appropriate course content and associated TESTS + MINUMUM GRADE
        [Required]
        public string Content { get; set; }

        public virtual Course Course { get; set; }
    }
}