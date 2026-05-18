using GestionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionProject.Infrastructure.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Contenu)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(f => f.Rapport)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.RapportId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Encadrant)
                .WithMany()
                .HasForeignKey(f => f.EncadrantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
