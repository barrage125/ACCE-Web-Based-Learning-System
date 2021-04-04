using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class TestGrade
    {
        public int ID { get; set; }
        public int GRADE { get; set; }
        public int TEST_ATTEMPT_ID { get; set; }
        public int USER_ID { get; set; }
        public virtual TestAttempt test_attempt { get; set; }
        public virtual User user { get; set; }
    }
}