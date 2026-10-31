using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.DeleteStudent;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/students/{id:guid}", async (
            Guid id,
            ICommandHandler<Command> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Command(id);
            var result = await handler.Handle(command, cancellationToken);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        })
        .WithTags(Tags.Students);
    }
}