using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Courses;

namespace Uni.Web.API.Database.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Unit).IsRequired();
            builder.Property(c => c.Code).IsRequired().HasMaxLength(7);
            builder.HasIndex(c => c.Code).IsUnique();
        }
    }
}
