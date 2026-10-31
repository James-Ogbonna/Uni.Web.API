using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudents;

public sealed record Query(
    Guid? DepartmentId,
    string? EntrySession,
    int? CurrentLevel
    )
    : IQuery<List<Response>>;