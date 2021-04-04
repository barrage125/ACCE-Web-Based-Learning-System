using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Section
    {
        [Required, RegularExpression(@"^.{1,2}$",
            ErrorMessage = "1-2 character section label required.")]
        public int SectionNo { get; set; }
        public Nullable<int> Capacity { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Key]
        public string ID
        {
            get { return CourseID + "-" + SectionNo; }
        }
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> enrollments { get; set; }
    }
}