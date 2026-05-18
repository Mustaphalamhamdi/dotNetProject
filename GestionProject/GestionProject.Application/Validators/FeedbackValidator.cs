using FluentValidation;
using GestionProject.Application.DTOs;

namespace GestionProject.Application.Validators
{
    public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackDto>
    {
        public CreateFeedbackValidator()
        {
            RuleFor(x => x.Contenu).NotEmpty().WithMessage("Le contenu est obligatoire.").MaximumLength(2000);
            RuleFor(x => x.RapportId).GreaterThan(0).WithMessage("Le rapport est obligatoire.");
            RuleFor(x => x.EncadrantId).GreaterThan(0).WithMessage("L'encadrant est obligatoire.");
        }
    }

    public class UpdateFeedbackValidator : AbstractValidator<UpdateFeedbackDto>
    {
        public UpdateFeedbackValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Contenu).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.RapportId).GreaterThan(0);
            RuleFor(x => x.EncadrantId).GreaterThan(0);
        }
    }
}
