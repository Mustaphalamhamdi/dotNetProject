using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateEvaluationValidator : AbstractValidator<CreateEvaluationDto>
    {
        public CreateEvaluationValidator()
        {
            RuleFor(x => x.Note).InclusiveBetween(0, 20).WithMessage("La note doit être entre 0 et 20.");
            RuleFor(x => x.SoutenanceId).GreaterThan(0).WithMessage("La soutenance est obligatoire.");
            RuleFor(x => x.MembreJuryId).GreaterThan(0).WithMessage("Le membre du jury est obligatoire.");
        }
    }

    public class UpdateEvaluationValidator : AbstractValidator<UpdateEvaluationDto>
    {
        public UpdateEvaluationValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Note).InclusiveBetween(0, 20);
            RuleFor(x => x.SoutenanceId).GreaterThan(0);
            RuleFor(x => x.MembreJuryId).GreaterThan(0);
        }
    }
}
