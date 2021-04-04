using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string ID { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}