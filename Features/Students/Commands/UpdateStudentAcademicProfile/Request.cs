namespace Uni.Web.API.Features.Students.Commands.UpdateStudentAcademicProfile;

public sealed record Request(
    string RegNumber,
    string EntrySession,
    int CurrentLevel,
    Guid DepartmentId);
