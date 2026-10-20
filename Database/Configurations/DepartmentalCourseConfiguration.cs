using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Courses;
using Uni.Web.API.Features.DepartmentalCourse;
using Uni.Web.API.Features.Departments;

namespace Uni.Web.API.Database.Configurations
{
    public class DepartmentalCourseConfiguration : IEntityTypeConfiguration<DepartmentalCourse>
    {
        public void Configure(EntityTypeBuilder<DepartmentalCourse> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.Property(dc => dc.DepartmentId).IsRequired();
            builder.Property(dc => dc.CourseId).IsRequired();
            builder.Property(dc => dc.Level).IsRequired();
            builder.Property(dc => dc.Semester).IsRequired().HasMaxLength(1);
            builder.Property(dc => dc.Status).IsRequired().HasMaxLength(20);
            builder.HasIndex(dc => new { dc.DepartmentId, dc.CourseId }).IsUnique();
            builder.HasOne<Department>().WithMany().HasForeignKey(dc => dc.DepartmentId);
            builder.HasOne<Course>().WithMany().HasForeignKey(dc => dc.CourseId);
        }
    }
}
