using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class EncadrantConfiguration : IEntityTypeConfiguration<Encadrant>
    {
        public void Configure(EntityTypeBuilder<Encadrant> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Prenom)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
