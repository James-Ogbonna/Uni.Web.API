namespace Uni.Web.API.Features.Courses;
public sealed class Course
{
    public Guid Id { get; set; } //uuid
    public string Code { get; set; } //SEN 323, CSC 327, SOE 224
    public string Title { get; set; }
    public int Unit { get; set; }
    public string Description { get; set; } =string.Empty;
}
