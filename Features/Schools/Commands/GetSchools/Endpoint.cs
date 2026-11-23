using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/schools/get-schools", async (
            Request request,
            ICommandHandler<Command, List<Response>> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Command(
                request.StudentId,
                request.RegNumber,
                request.Email,
                request.DepartmentId,
                request.EntrySession,
                request.CurrentLevel);

            var result = await handler.Handle(command, cancellationToken);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        })
        .WithTags(Tags.Schools);
    }
}
