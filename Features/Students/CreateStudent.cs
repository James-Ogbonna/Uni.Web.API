using FluentValidation;
using Uni.Web.API.Common;
using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Students
{
    public class CreateStudent
    {
        public sealed record Command(
            string RegNumber,
            string FirstName,
            string LastName,
            DateOnly DateOfBirth,
            string Email,
            string PhoneNumber,
            Guid DepartmentId,
            int Level)
            : ICommand<Guid>;

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.RegNumber).NotEmpty().MaximumLength(11);
                RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
                RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
                RuleFor(x => x.DateOfBirth).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(11);
                RuleFor(x => x.DepartmentId).NotEmpty();
                RuleFor(x => x.Level).GreaterThan(0);
            }
        }

        public sealed class Handler(ApplicationDbContext context) : ICommandHandler<Command, Guid>
        {
            public async Task<ServiceResponse<Guid>> Handle(Command command, CancellationToken cancellationToken)
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    RegNumber = command.RegNumber,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth,
                    Email = command.Email,
                    PhoneNumber = command.PhoneNumber,
                    DepartmentId = command.DepartmentId,
                    Level = command.Level
                };

                context.Students.Add(student);
                await context.SaveChangesAsync(cancellationToken);

                return new ServiceResponse<Guid>
                {
                    Data = student.Id
                };
            }
        }

        public sealed class EndPoint : IEndpoint
        {
            public sealed record Request(
           string RegNumber,
           string FirstName,
           string LastName,
           DateOnly DateOfBirth,
           string Email,
           string PhoneNumber,
           Guid DepartmentId,
           int Level);


            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPost("/api/students", async (Request request, ICommandHandler<Command, Guid> handler, CancellationToken cancellationToken) =>
                {
                    var command = new Command(
                        request.RegNumber,
                        request.FirstName,
                        request.LastName,
                        request.DateOfBirth,
                        request.Email,
                        request.PhoneNumber,
                        request.DepartmentId,
                        Level: request.Level
                    );

                    var response = await handler.Handle(command, cancellationToken);
                    return Results.Ok(response);
                });
            }
        }
    }
}