using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateSeanceValidator : AbstractValidator<CreateSeanceDto>
    {
        public CreateSeanceValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("La date est obligatoire.");
            RuleFor(x => x.Type).NotEmpty().Must(t => t == "Presentielle" || t == "Distancielle").WithMessage("Le type doit être Presentielle ou Distancielle.");
            RuleFor(x => x.ProjetId).GreaterThan(0).WithMessage("Le projet est obligatoire.");
            RuleFor(x => x.EncadrantId).GreaterThan(0).WithMessage("L'encadrant est obligatoire.");
        }
    }

    public class UpdateSeanceValidator : AbstractValidator<UpdateSeanceDto>
    {
        public UpdateSeanceValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Type).NotEmpty().Must(t => t == "Presentielle" || t == "Distancielle");
            RuleFor(x => x.ProjetId).GreaterThan(0);
            RuleFor(x => x.EncadrantId).GreaterThan(0);
        }
    }
}
