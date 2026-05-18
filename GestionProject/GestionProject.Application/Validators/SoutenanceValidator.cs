using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateSoutenanceValidator : AbstractValidator<CreateSoutenanceDto>
    {
        public CreateSoutenanceValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("La date est obligatoire.");
            RuleFor(x => x.Lieu).NotEmpty().WithMessage("Le lieu est obligatoire.").MaximumLength(200);
            RuleFor(x => x.ProjetId).GreaterThan(0).WithMessage("Le projet est obligatoire.");
            RuleFor(x => x.MembresJuryIds).NotEmpty().WithMessage("Au moins un membre du jury est requis.");
        }
    }

    public class UpdateSoutenanceValidator : AbstractValidator<UpdateSoutenanceDto>
    {
        public UpdateSoutenanceValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Lieu).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ProjetId).GreaterThan(0);
            RuleFor(x => x.MembresJuryIds).NotEmpty();
        }
    }
}
