using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Course
    {
        [Required, RegularExpression(@"^[0-9]{4}$",
            ErrorMessage = "4-Digit course numbers only.")]
        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        [Required]
        public string DepartmentID { get; set; }
        [Key]
        public string ID
        {
            get { return DepartmentID + " " + CourseNo; }
        }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}