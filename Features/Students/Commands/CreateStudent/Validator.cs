using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Uni.Web.API.Features.Students.Commands.CreateStudent;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.RegNumber).NotEmpty().MaximumLength(10);
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now));
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(70);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(11);
        RuleFor(x => x.EntrySession).NotEmpty().MaximumLength(9);
        RuleFor(x => x.Currentevel).NotEmpty();
        RuleFor(x => x.DepartmentId).NotEmpty();
    }
}