using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Courses;

namespace Uni.Web.API.Database.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id); //Primary key
            builder.Property(c => c.Code).IsRequired().HasMaxLength(7);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Unit).IsRequired();
        }
    }
}
