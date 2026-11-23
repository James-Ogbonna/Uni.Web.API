using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

// Fetches the school(s) of the student(s) matching the given student
// information. A student belongs to a school through their department:
// Student.DepartmentId -> Department.SchoolId -> School.
public sealed record Command(
    Guid? StudentId,
    string? RegNumber,
    string? Email,
    Guid? DepartmentId,
    string? EntrySession,
    int? CurrentLevel)
    : ICommand<List<Response>>;
