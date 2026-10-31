using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudentByRegNumber;

public sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/students/reg-number", async (
            string value,
            IQueryHandler<Query, Response> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new Query(value);

            var result = await handler.Handle(command, cancellationToken);

            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        })
        .WithTags(Tags.Students);
    }
}