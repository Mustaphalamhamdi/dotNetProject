using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class EtudiantConfiguration : IEntityTypeConfiguration<Etudiant>
    {
        public void Configure(EntityTypeBuilder<Etudiant> builder)
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

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
