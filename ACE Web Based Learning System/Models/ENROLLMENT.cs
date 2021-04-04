﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System.Models
{
    public class Enrollment
    {
        [Required]
        public string Type { get; set; }
        public int SectionID { get; set; }
        public int UserID { get; set; }
        [Key]
        public string ID
        {
            get { return SectionID + "," + UserID; }
        }
        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
    }
}