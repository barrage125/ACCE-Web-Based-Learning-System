using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class TestAttempt
    {
        public int ID { get; set; }

        //Holds JSON data representing student-submitted answers to test questions
        public string ANSWERS { get; set; }
    }
}