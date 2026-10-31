using FluentValidation;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudent;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now));
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(70);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(11);
    }
}
