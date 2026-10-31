using FluentValidation;

namespace Uni.Web.API.Features.Students.Commands.DeleteStudent;

public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
        }
    }
