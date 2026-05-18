using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateEncadrantValidator : AbstractValidator<CreateEncadrantDto>
    {
        public CreateEncadrantValidator()
        {
            RuleFor(x => x.Nom).NotEmpty().WithMessage("Le nom est obligatoire.").MaximumLength(100);
            RuleFor(x => x.Prenom).NotEmpty().WithMessage("Le prénom est obligatoire.").MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("L'email est invalide.").MaximumLength(150);
            RuleFor(x => x.Type).NotEmpty().Must(t => t == "Academique" || t == "Professionnel").WithMessage("Le type doit être Academique ou Professionnel.");
        }
    }

    public class UpdateEncadrantValidator : AbstractValidator<UpdateEncadrantDto>
    {
        public UpdateEncadrantValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Nom).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Prenom).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
            RuleFor(x => x.Type).NotEmpty().Must(t => t == "Academique" || t == "Professionnel");
        }
    }
}
