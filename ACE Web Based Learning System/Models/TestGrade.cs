using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class TestGrade
    {
        public int ID { get; set; }
        public Nullable<int> Grade { get; set; }
        public int TestAttemptID { get; set; }
        public int UserID { get; set; }
        public virtual TestAttempt test_attempt { get; set; }
        public virtual User User { get; set; }
    }
}