using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class ProjetConfiguration : IEntityTypeConfiguration<Projet>
    {
        public void Configure(EntityTypeBuilder<Projet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titre)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Statut)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(p => p.Etudiant)
                .WithMany(e => e.Projets)
                .HasForeignKey(p => p.EtudiantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.EncadrantAcademique)
                .WithMany()
                .HasForeignKey(p => p.EncadrantAcademiqueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.EncadrantProfessionnel)
                .WithMany()
                .HasForeignKey(p => p.EncadrantProfessionnelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
