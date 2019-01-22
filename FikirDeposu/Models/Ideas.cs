namespace FikirDeposu.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[JsonObject(IsReference = true)]
    public partial class Ideas
    {
        [Key]
        public int ideaID { get; set; }

        public int? number { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public DateTime? ideaDate { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public bool? isActive { get; set; }

        public DateTime? clasureDate { get; set; }

        public int? userID { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}
