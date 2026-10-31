using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.DepartmentalCourse;

namespace Uni.Web.API.Database.Configurations
{
    public sealed class DepartmentalCourseConfiguration : IEntityTypeConfiguration<DepartmentalCourse>
    {
        public void Configure(EntityTypeBuilder<DepartmentalCourse> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.HasIndex(dc => new { dc.DepartmentId, dc.CourseId }).IsUnique();
            builder.Property(dc => dc.Level).IsRequired();
            builder.Property(dc => dc.Semester).IsRequired().HasMaxLength(1);
            builder.Property(dc => dc.Status).IsRequired().HasMaxLength(10);
        }
    }
}
