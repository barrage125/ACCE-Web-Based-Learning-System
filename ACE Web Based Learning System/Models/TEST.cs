using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Test
    {
        public int ID { get; set; }

        //Holds JSON data representing test questions, correct answers, and type
        [Required]
        public string QUESTIONS { get; set; }
        [Required]
        public int CourseID { get; set; }
        //public int TestAttemptID { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<TestAttempt> TestAttempts { get; set; }
        
    }
}