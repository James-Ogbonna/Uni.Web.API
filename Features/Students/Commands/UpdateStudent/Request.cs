namespace Uni.Web.API.Features.Students.Commands.UpdateStudent;
public sealed record Request(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string PhoneNumber);
