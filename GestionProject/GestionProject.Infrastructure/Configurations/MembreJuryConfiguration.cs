using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class MembreJuryConfiguration : IEntityTypeConfiguration<MembreJury>
    {
        public void Configure(EntityTypeBuilder<MembreJury> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nom)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Prenom)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(m => m.Email)
                .IsUnique();
        }
    }
}
