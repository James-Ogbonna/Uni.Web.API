using Uni.Web.API.Features.Students;
using Uni.Web.API.Features.DepartmentalCourse;

namespace Uni.Web.API.Features.Departments;
public sealed class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Abbr { get; set; }
    public Guid SchoolId { get; set; }
}
