namespace Uni.Web.API.Features.Departments;
public sealed class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SchoolId { get; set; }

   // public List<Student>? Students { get; set; }
}
