using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudent;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/students/{id:guid}", async (
            Guid id,
            Request request,
            ICommandHandler<Command> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Command(
                id,
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber
            );

            var result = await handler.Handle(command, cancellationToken);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        })
        .WithTags(Tags.Students);
    }
}
