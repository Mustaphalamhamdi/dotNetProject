using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateEtudiantValidator : AbstractValidator<CreateEtudiantDto>
    {
        public CreateEtudiantValidator()
        {
            RuleFor(x => x.Nom).NotEmpty().WithMessage("Le nom est obligatoire.").MaximumLength(100);
            RuleFor(x => x.Prenom).NotEmpty().WithMessage("Le prénom est obligatoire.").MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("L'email est invalide.").MaximumLength(150);
        }
    }

    public class UpdateEtudiantValidator : AbstractValidator<UpdateEtudiantDto>
    {
        public UpdateEtudiantValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Nom).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Prenom).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
        }
    }
}
