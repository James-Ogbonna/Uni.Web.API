using FluentValidation;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudentAcademicProfile;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.RegNumber).NotEmpty().MaximumLength(11);
        RuleFor(x => x.EntrySession).NotEmpty().MaximumLength(9);
        RuleFor(x => x.CurrentLevel).NotEmpty();
        RuleFor(x => x.DepartmentId).NotEmpty();
    }
}
