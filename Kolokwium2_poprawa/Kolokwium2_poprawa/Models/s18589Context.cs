using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kolokwium2_poprawa.Models
{
    public partial class s18589Context : DbContext
    {
        public s18589Context()
        {
        }

        public s18589Context(DbContextOptions<s18589Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BreedType> BreedType { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }
        public virtual DbSet<VolunteerPet> VolunteerPet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreedType>(entity =>
            {
                entity.HasKey(e => e.IdBreedType)
                    .HasName("BreedType_pk");

                entity.Property(e => e.IdBreedType).ValueGeneratedNever();

                entity.Property(e => e.Descrpition).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("Pet_pk");

                entity.Property(e => e.IdPet).ValueGeneratedNever();

                entity.Property(e => e.ApprocimateDateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateAdopted).HasColumnType("datetime");

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdBreedTypeNavigation)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.IdBreedType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_BreedType");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("Volunteer_pk");

                entity.Property(e => e.IdVolunteer)
                    .HasColumnName("Id_Volunteer")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.IdSupervisor).HasColumnName("Id_Supervisor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.InverseIdSupervisorNavigation)
                    .HasForeignKey(d => d.IdSupervisor)
                    .HasConstraintName("Volunteer_Volunteer");
            });

            modelBuilder.Entity<VolunteerPet>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdPet })
                    .HasName("Volunteer_Pet_pk");

                entity.ToTable("Volunteer_Pet");

                entity.Property(e => e.IdVolunteer).HasColumnName("Id_Volunteer");

                entity.Property(e => e.DateAccepted).HasColumnType("datetime");

                entity.HasOne(d => d.IdPetNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdPet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Pet");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
