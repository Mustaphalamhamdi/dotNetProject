using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class SoutenanceConfiguration : IEntityTypeConfiguration<Soutenance>
    {
        public void Configure(EntityTypeBuilder<Soutenance> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Lieu)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(s => s.Projet)
                .WithOne(p => p.Soutenance)
                .HasForeignKey<Soutenance>(s => s.ProjetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.MembresJury)
                .WithMany(m => m.Soutenances);
        }
    }
}
