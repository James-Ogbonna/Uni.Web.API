namespace Uni.Web.API.Features.Students.Queries.GetStudentByRegNumber;

public sealed record Response(
    Guid Id, 
    string RegNumber, 
    string FirstName, 
    string LastName,
    DateOnly DateOfBirth, 
    string Email,
    string PhoneNumber, 
    string EntrySession, 
    int CurrentLevel, 
    Guid DepartmentId);


