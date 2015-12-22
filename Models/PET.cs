namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PET")]
    public partial class PET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PET()
        {
            VISIT = new HashSet<VISIT>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthdate { get; set; }

        [Display(Name = "Pet type")]
        public int? pet_type { get; set; }

        public int? owner { get; set; }

        public virtual OWNER OWNER1 { get; set; }

        public virtual PET_TYPE PET_TYPE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISIT { get; set; }

        public static IEnumerable< System.Web.Mvc.SelectListItem>
            PetTypeDescs
        {
            get
            {
                return DL.AllPetTypeDescriptions() ; 
            }
        }
    }
}
