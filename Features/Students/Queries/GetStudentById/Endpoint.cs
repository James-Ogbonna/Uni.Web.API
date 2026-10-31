using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudentById;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/students/{id:guid}", async (
            Guid id,
            IQueryHandler<Query, Response> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Query(id);

            var result = await handler.Handle(command, cancellationToken);

            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        })
        .WithTags(Tags.Students);
    }
}

