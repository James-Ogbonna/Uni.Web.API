using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.CreateStudent;

public sealed record Command(
    string RegNumber,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string PhoneNumber,
    string EntrySession,
    int Currentevel,
    Guid DepartmentId)
    : ICommand<Guid>;
