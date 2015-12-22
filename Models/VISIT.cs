namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISIT")]
    public partial class VISIT
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "description of visit")]
        public string description { get; set; }

        public int pet { get; set; }

        public virtual PET PET1 { get; set; }
    }
}
