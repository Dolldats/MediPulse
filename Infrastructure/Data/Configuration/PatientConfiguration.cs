using MediPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediPulse.Infrastructure.Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .HasMaxLength(250);

            builder.Property(p => p.BloodGroup)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.EmergencyContact)
                .HasMaxLength(20);

            builder.Property(p => p.CreatedAt)
                .IsRequired();
        }
    }
}

