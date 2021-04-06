using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required, RegularExpression(@"^[A-Z]+.*$",
            ErrorMessage = "Must be capital and at least one letter.")]



        public string LastName { get; set; }
        [Required, RegularExpression(@"^[A-Z]+.*$",
            ErrorMessage = "Must be capital and at least one letter.")]
        public string FirstName { get; set; }

        public virtual UserContent UserContent { get; set; }
        
        public virtual Credential Credential { get; set; }
        [ForeignKey("ID")]
        public virtual ICollection<TestGrade> TestGrades { get; set; }
        public virtual ICollection<TestAttempt> TestAttempts { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}