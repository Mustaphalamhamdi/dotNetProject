using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateProjetValidator : AbstractValidator<CreateProjetDto>
    {
        public CreateProjetValidator()
        {
            RuleFor(x => x.Titre).NotEmpty().WithMessage("Le titre est obligatoire.").MaximumLength(200);
            RuleFor(x => x.Type).NotEmpty().WithMessage("Le type est obligatoire.").Must(t => t == "PFE" || t == "PFA").WithMessage("Le type doit être PFE ou PFA.");
            RuleFor(x => x.EtudiantId).GreaterThan(0).WithMessage("L'étudiant est obligatoire.");
            RuleFor(x => x.EncadrantAcademiqueId).GreaterThan(0).WithMessage("L'encadrant académique est obligatoire.");
        }
    }

    public class UpdateProjetValidator : AbstractValidator<UpdateProjetDto>
    {
        public UpdateProjetValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Titre).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Type).NotEmpty().Must(t => t == "PFE" || t == "PFA");
            RuleFor(x => x.Statut).NotEmpty().Must(s => s == "Proposé" || s == "En cours" || s == "Soutenu");
            RuleFor(x => x.EtudiantId).GreaterThan(0);
            RuleFor(x => x.EncadrantAcademiqueId).GreaterThan(0);
        }
    }
}
