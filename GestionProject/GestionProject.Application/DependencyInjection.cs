using FluentValidation;
using GestionProject.Application.Mappings;
using GestionProject.Application.Services.Implementations;
using GestionProject.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GestionProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<MappingProfile>();

            // Services
            services.AddScoped<IProjetService, ProjetService>();
            services.AddScoped<IEtudiantService, EtudiantService>();
            services.AddScoped<IEncadrantService, EncadrantService>();
            services.AddScoped<IRapportService, RapportService>();
            services.AddScoped<ISeanceService, SeanceService>();
            services.AddScoped<ISoutenanceService, SoutenanceService>();
            services.AddScoped<IMembreJuryService, MembreJuryService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IEvaluationService, EvaluationService>();

            return services;
        }
    }
}
