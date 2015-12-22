namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VET")]
    public partial class VET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VET()
        {
            VET_SPECIALTIES = new HashSet<VET_SPECIALTIES>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string firstname { get; set; }

        [Required]
        [StringLength(200)]
        public string lastname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VET_SPECIALTIES> VET_SPECIALTIES { get; set; }
    }
}
