using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class TestAttempt
    {
        public int ID { get; set; }

        //Holds JSON data representing student-submitted answers to test questions
        [Required]
        public string ANSWERS { get; set; }
        public int TestID { get; set; }
        public int UserID { get; set; }
        public int TestGradeID { get; set; }
        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
        public virtual TestGrade TestGrade { get; set; }
    }
}