namespace PetClinic.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
            : base("name=CodeFirstContext")
        {
        }

        public virtual DbSet<OWNER> OWNER { get; set; }
        public virtual DbSet<PET> PET { get; set; }
        public virtual DbSet<PET_TYPE> PET_TYPE { get; set; }
        public virtual DbSet<SPECIALTY> SPECIALTY { get; set; }
        public virtual DbSet<VET> VET { get; set; }
        public virtual DbSet<VET_SPECIALTIES> VET_SPECIALTIES { get; set; }
        public virtual DbSet<VISIT> VISIT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OWNER>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .HasMany(e => e.PET)
                .WithOptional(e => e.OWNER1)
                .HasForeignKey(e => e.owner);

            modelBuilder.Entity<PET>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PET>()
                .HasMany(e => e.VISIT)
                .WithRequired(e => e.PET1)
                .HasForeignKey(e => e.pet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PET_TYPE>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PET_TYPE>()
                .HasMany(e => e.PET)
                .WithOptional(e => e.PET_TYPE1)
                .HasForeignKey(e => e.pet_type);

            modelBuilder.Entity<SPECIALTY>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<SPECIALTY>()
                .HasMany(e => e.VET_SPECIALTIES)
                .WithRequired(e => e.SPECIALTY1)
                .HasForeignKey(e => e.specialty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VET>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<VET>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<VET>()
                .HasMany(e => e.VET_SPECIALTIES)
                .WithRequired(e => e.VET1)
                .HasForeignKey(e => e.vet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
