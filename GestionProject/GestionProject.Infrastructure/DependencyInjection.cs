using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GestionProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProjetRepository, ProjetRepository>();
            services.AddScoped<IEtudiantRepository, EtudiantRepository>();
            services.AddScoped<IEncadrantRepository, EncadrantRepository>();
            services.AddScoped<IRapportRepository, RapportRepository>();
            services.AddScoped<ISeanceRepository, SeanceRepository>();
            services.AddScoped<ISoutenanceRepository, SoutenanceRepository>();
            services.AddScoped<IMembreJuryRepository, MembreJuryRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();

            return services;
        }
    }
}
