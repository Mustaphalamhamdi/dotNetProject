using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class RapportConfiguration : IEntityTypeConfiguration<Rapport>
    {
        public void Configure(EntityTypeBuilder<Rapport> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Version)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.CheminFichier)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(r => r.Projet)
                .WithMany(p => p.Rapports)
                .HasForeignKey(r => r.ProjetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
