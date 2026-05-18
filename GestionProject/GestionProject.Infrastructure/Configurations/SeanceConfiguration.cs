using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class SeanceConfiguration : IEntityTypeConfiguration<Seance>
    {
        public void Configure(EntityTypeBuilder<Seance> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Notes)
                .HasMaxLength(2000);

            builder.Property(s => s.Commentaires)
                .HasMaxLength(2000);

            builder.HasOne(s => s.Projet)
                .WithMany(p => p.Seances)
                .HasForeignKey(s => s.ProjetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Encadrant)
                .WithMany()
                .HasForeignKey(s => s.EncadrantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
