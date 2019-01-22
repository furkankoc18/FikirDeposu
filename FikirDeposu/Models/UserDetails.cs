namespace FikirDeposu.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[JsonObject(IsReference = true)]
    public partial class UserDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetails()
        {
            Ideas = new HashSet<Ideas>();
        }

        [Key]
        public int userID { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public DateTime? registerDate { get; set; }

        public bool? isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ideas> Ideas { get; set; }
    }
}
