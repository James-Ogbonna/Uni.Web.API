using System.Runtime.CompilerServices;
using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudents;

public sealed class Endpoint : IEndpoint
{
    //This endpoint is used to retrieve a list of students based on
    //optional filters such as departmentId, entrySession, and currentLevel.
    //The endpoint supports the following query parameters:
    //https://localhost:7233/api/students
    //https://localhost:7233/api/students?currentLevel=300
    //https://localhost:7233/api/students?departmentId=b92292a7-8a46-4a51-89a8-57a3485906ea
    //https://localhost:7233/api/students?departmentId=b92292a7-8a46-4a51-89a8-57a3485906ea&entrySession=2023/2024
    //https://localhost:7233/api/students?departmentId=b92292a7-8a46-4a51-89a8-57a3485906ea&entrySession=2022/2023&currentLevel=300

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/students", async (
            Guid? departmentId,
            string? entrySession,
            int? currentLevel,
            IQueryHandler<Query, List<Response>> handler,
            CancellationToken cancellationToken) =>
        {

            var query = new Query(
                departmentId,
                entrySession,
                currentLevel);

            var result = await handler.Handle(query, cancellationToken);

            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        })
        .WithTags(Tags.Students);
    }
}

