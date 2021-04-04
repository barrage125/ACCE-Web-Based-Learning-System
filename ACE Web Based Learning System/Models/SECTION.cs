using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Section
    {
        public int ID { get; set; }
        public int CAPACITY { get; set; }
        public int COURSE_ID { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> enrollments { get; set; }
    }
}