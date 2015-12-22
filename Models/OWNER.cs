namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OWNER")]
    public partial class OWNER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OWNER()
        {
            PET = new HashSet<PET>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string firstname { get; set; }

        [Required]
        [StringLength(200)]
        public string lastname { get; set; }

        [Required]
        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(200)]
        public string city { get; set; }

        [Required]
        [StringLength(200)]
        public string telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PET> PET { get; set; }
    }
}
