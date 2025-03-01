using FluentValidation;
using MasterData.Application.Commands;

namespace MasterData.Application.Validators;

public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
{
    public CreateScheduleCommandValidator()
    {
        RuleFor(o => o.Name)
            .NotEmpty()
            .WithMessage("{Name} is required")
            .NotNull()
            .MinimumLength(2)
            .WithMessage("{Name} must be at least 2 characters long")
            .MaximumLength(50)
            .WithMessage("{Name} must be a maximum of 50 characters");
    }
}