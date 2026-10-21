using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Features.CourseRegistrations;
using Uni.Web.API.Features.Courses;
using Uni.Web.API.Features.DepartmentalCourse;
using Uni.Web.API.Features.Departments;
using Uni.Web.API.Features.Schools;
using Uni.Web.API.Features.Students;

namespace Uni.Web.API.Database;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: DbContext(options)
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<DepartmentalCourse> DepartmentalCourses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseRegistration> CourseRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
    }
}
