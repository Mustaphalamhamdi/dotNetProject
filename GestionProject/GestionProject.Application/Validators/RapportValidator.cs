using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateRapportValidator : AbstractValidator<CreateRapportDto>
    {
        public CreateRapportValidator()
        {
            RuleFor(x => x.Version).NotEmpty().WithMessage("La version est obligatoire.").MaximumLength(50);
            RuleFor(x => x.CheminFichier).NotEmpty().WithMessage("Le chemin du fichier est obligatoire.");
            RuleFor(x => x.ProjetId).GreaterThan(0).WithMessage("Le projet est obligatoire.");
        }
    }

    public class UpdateRapportValidator : AbstractValidator<UpdateRapportDto>
    {
        public UpdateRapportValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Version).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CheminFichier).NotEmpty();
            RuleFor(x => x.ProjetId).GreaterThan(0);
        }
    }
}
