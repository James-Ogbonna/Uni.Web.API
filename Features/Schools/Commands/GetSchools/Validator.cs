using FluentValidation;

namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x)
            .Must(x => x.StudentId.HasValue
                || !string.IsNullOrWhiteSpace(x.RegNumber)
                || !string.IsNullOrWhiteSpace(x.Email)
                || x.DepartmentId.HasValue
                || !string.IsNullOrWhiteSpace(x.EntrySession)
                || x.CurrentLevel.HasValue)
            .WithMessage("At least one student information must be provided.");

        RuleFor(x => x.RegNumber)
            .MaximumLength(11)
            .When(x => !string.IsNullOrWhiteSpace(x.RegNumber));

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(70)
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.EntrySession)
            .MaximumLength(9)
            .When(x => !string.IsNullOrWhiteSpace(x.EntrySession));

        RuleFor(x => x.CurrentLevel)
            .GreaterThan(0)
            .When(x => x.CurrentLevel.HasValue);
    }
}
