using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Note)
                .IsRequired();

            builder.Property(e => e.Commentaire)
                .HasMaxLength(2000);

            builder.HasOne(e => e.Soutenance)
                .WithMany()
                .HasForeignKey(e => e.SoutenanceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MembreJury)
                .WithMany()
                .HasForeignKey(e => e.MembreJuryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
