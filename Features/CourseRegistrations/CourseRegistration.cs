namespace Uni.Web.API.Features.CourseRegistrations;
public sealed class CourseRegistration
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public string Session { get; set; } //2024-2025
    public Semester Semester { get; set; } 
    //public DateTime RegistrationDate { get; set; }
}
