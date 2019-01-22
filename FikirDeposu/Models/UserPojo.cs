using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FikirDeposu.Models
{
    public class UserPojo
    {
        public int userID { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public DateTime? registerDate { get; set; }

        public bool? isActive { get; set; }
    }
}