namespace Uni.Web.API.Features.Students;
public sealed class Student
{
    public Guid Id { get; set; }
    public string RegNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public int Level { get; set; }
   
}
