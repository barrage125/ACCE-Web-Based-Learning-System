using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DEPT_NAME { get; set; }
        public int COURSE_ID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}