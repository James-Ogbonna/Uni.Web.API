using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.CreateStudent;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/students", async (
            Request request,
            ICommandHandler<Command, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Command(
                request.RegNumber,
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber,
                request.EntrySession,
                request.CurrentLevel,
                request.DepartmentId);

            var result = await handler.Handle(command, cancellationToken);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        })
        .WithTags(Tags.Students);
    }
}