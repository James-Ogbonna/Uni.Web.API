using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.UpdateStudent;

//Here, we don't want to update the following:
// RegNumber, Level, DepartmentId
//These are admin roles and should be done in a separate endpoint.
public sealed record Command(
    Guid StudentId,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string PhoneNumber)
    : ICommand;
