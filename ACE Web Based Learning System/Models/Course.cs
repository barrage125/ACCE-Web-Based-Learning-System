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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string CourseName { get; set; }
        public int CourseContent { get; set; }
        [Required]
        public string DEPARTMENT_ID { get; set; }

        public virtual CourseContent CourseContent { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}