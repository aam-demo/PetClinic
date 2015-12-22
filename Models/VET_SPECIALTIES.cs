namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VET_SPECIALTIES
    {
        public int id { get; set; }

        public int vet { get; set; }

        public int specialty { get; set; }

        public virtual SPECIALTY SPECIALTY1 { get; set; }

        public virtual VET VET1 { get; set; }
    }
}
