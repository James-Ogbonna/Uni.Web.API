namespace Uni.Web.API.Features.DepartmentalCourse;
public sealed class DepartmentalCourse
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid CourseId { get; set; }
    public int Level { get; set; } //100, 200, 300, 400, 500
    public Semester Semester { get; set; } //Hammatan, Rain
    public string Status { get; set; } //Compulsory, Elective
}
