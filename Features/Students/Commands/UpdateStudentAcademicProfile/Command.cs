using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudentAcademicProfile;

public sealed record Command(
    Guid StudentId,
    string RegNumber,
    string EntrySession,
    int CurrentLevel,
    Guid DepartmentId)
    : ICommand;