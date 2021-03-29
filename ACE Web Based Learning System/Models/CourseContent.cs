using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class CourseContent
    {
        public CourseContent()
        {
            this.Courses = new HashSet<Courses>();
        }

        public int ID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
    }
}