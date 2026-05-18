using GestionProject.Domain.Entities;
using GestionProject.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Data
{
    public class GestionDbContext : DbContext
    {
        public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Encadrant> Encadrants { get; set; }
        public DbSet<Rapport> Rapports { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Soutenance> Soutenances { get; set; }
        public DbSet<MembreJury> MembresJury { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProjetConfiguration());
            modelBuilder.ApplyConfiguration(new EtudiantConfiguration());
            modelBuilder.ApplyConfiguration(new EncadrantConfiguration());
            modelBuilder.ApplyConfiguration(new RapportConfiguration());
            modelBuilder.ApplyConfiguration(new SeanceConfiguration());
            modelBuilder.ApplyConfiguration(new SoutenanceConfiguration());
            modelBuilder.ApplyConfiguration(new MembreJuryConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationConfiguration());
        }
    }
}