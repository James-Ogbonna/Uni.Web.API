namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

public sealed record Request(
    Guid? StudentId,
    string? RegNumber,
    string? Email,
    Guid? DepartmentId,
    string? EntrySession,
    int? CurrentLevel);
