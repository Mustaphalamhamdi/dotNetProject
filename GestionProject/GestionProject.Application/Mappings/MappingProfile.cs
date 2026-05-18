using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Domain.Entities;

namespace GestionProject.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Projet
            CreateMap<Projet, ProjetDto>()
                .ForMember(d => d.EtudiantNom, opt => opt.MapFrom(s => s.Etudiant != null ? $"{s.Etudiant.Nom} {s.Etudiant.Prenom}" : null))
                .ForMember(d => d.EncadrantAcademiqueNom, opt => opt.MapFrom(s => s.EncadrantAcademique != null ? $"{s.EncadrantAcademique.Nom} {s.EncadrantAcademique.Prenom}" : null))
                .ForMember(d => d.EncadrantProfessionnelNom, opt => opt.MapFrom(s => s.EncadrantProfessionnel != null ? $"{s.EncadrantProfessionnel.Nom} {s.EncadrantProfessionnel.Prenom}" : null));
            CreateMap<CreateProjetDto, Projet>();
            CreateMap<UpdateProjetDto, Projet>();

            // Etudiant
            CreateMap<Etudiant, EtudiantDto>();
            CreateMap<CreateEtudiantDto, Etudiant>();
            CreateMap<UpdateEtudiantDto, Etudiant>();

            // Encadrant
            CreateMap<Encadrant, EncadrantDto>();
            CreateMap<CreateEncadrantDto, Encadrant>();
            CreateMap<UpdateEncadrantDto, Encadrant>();

            // Rapport
            CreateMap<Rapport, RapportDto>()
                .ForMember(d => d.ProjetTitre, opt => opt.MapFrom(s => s.Projet != null ? s.Projet.Titre : null));
            CreateMap<CreateRapportDto, Rapport>();
            CreateMap<UpdateRapportDto, Rapport>();

            // Seance
            CreateMap<Seance, SeanceDto>()
                .ForMember(d => d.ProjetTitre, opt => opt.MapFrom(s => s.Projet != null ? s.Projet.Titre : null))
                .ForMember(d => d.EncadrantNom, opt => opt.MapFrom(s => s.Encadrant != null ? $"{s.Encadrant.Nom} {s.Encadrant.Prenom}" : null));
            CreateMap<CreateSeanceDto, Seance>();
            CreateMap<UpdateSeanceDto, Seance>();

            // Soutenance
            CreateMap<Soutenance, SoutenanceDto>()
                .ForMember(d => d.ProjetTitre, opt => opt.MapFrom(s => s.Projet != null ? s.Projet.Titre : null));
            CreateMap<CreateSoutenanceDto, Soutenance>()
                .ForMember(d => d.MembresJury, opt => opt.Ignore());
            CreateMap<UpdateSoutenanceDto, Soutenance>()
                .ForMember(d => d.MembresJury, opt => opt.Ignore());

            // MembreJury
            CreateMap<MembreJury, MembreJuryDto>();
            CreateMap<CreateMembreJuryDto, MembreJury>();
            CreateMap<UpdateMembreJuryDto, MembreJury>();

            // Feedback
            CreateMap<Feedback, FeedbackDto>()
                .ForMember(d => d.EncadrantNom, opt => opt.MapFrom(s => s.Encadrant != null ? $"{s.Encadrant.Nom} {s.Encadrant.Prenom}" : null));
            CreateMap<CreateFeedbackDto, Feedback>();
            CreateMap<UpdateFeedbackDto, Feedback>();

            // Evaluation
            CreateMap<Evaluation, EvaluationDto>()
                .ForMember(d => d.MembreJuryNom, opt => opt.MapFrom(s => s.MembreJury != null ? $"{s.MembreJury.Nom} {s.MembreJury.Prenom}" : null));
            CreateMap<CreateEvaluationDto, Evaluation>();
            CreateMap<UpdateEvaluationDto, Evaluation>();
        }
    }
}
