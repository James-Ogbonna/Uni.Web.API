using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudentAcademicProfile;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/students/{id:guid}/academic-profile", async (
            Guid id,
            Request request,
            ICommandHandler<Command> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Command(
                id,
                request.RegNumber,
                request.EntrySession,
                request.CurrentLevel,
                request.DepartmentId
            );

            var result = await handler.Handle(command, cancellationToken);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        })
        .WithTags(Tags.Students);
    }
}