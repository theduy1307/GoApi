using FluentValidation;
using MasterData.Application.Commands;

namespace MasterData.Application.Validators;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(o => o.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("{Id} is required");
        RuleFor(o => o.IsoCode)
            .NotEmpty()
            .WithMessage("{IsoCode} is required")
            .NotNull()
            .MaximumLength(2)
            .WithMessage("{IsoCode} must not exceed 2 characters");
        RuleFor(o => o.Name)
            .NotEmpty()
            .WithMessage("{Name} is required")
            .NotNull()
            .MaximumLength(100)
            .WithMessage("{IsoCode} must not exceed 2 characters");
    }
}