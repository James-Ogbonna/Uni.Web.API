namespace Uni.Web.API.Features.Students.Commands.CreateStudent;

public sealed record Request(
      string RegNumber,
      string FirstName,
      string LastName,
      DateOnly DateOfBirth,
      string Email,
      string PhoneNumber,
      string EntrySession,
      int CurrentLevel,
      Guid DepartmentId);