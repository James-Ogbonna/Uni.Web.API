namespace Uni.Web.API.Features.Courses;
public sealed class Course
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public int Unit { get; set; }
    public string Description { get; set; }
}
