using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FikirDeposu.Models
{
    public class IdeaPojo
    {
        public int ideaID { get; set; }
        public int? number { get; set; }
        public string name { get; set; }
        public DateTime? ideaDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public bool? isActive { get; set; }
       // public bool? isRendered { get; set; }
        public DateTime? clasureDate { get; set; }
        public int? userID { get; set; }
    }
}