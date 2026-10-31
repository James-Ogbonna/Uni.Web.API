using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Students;
using Uni.Web.API.Features.CourseRegistrations;
using Uni.Web.API.Features.Courses;

namespace Uni.Web.API.Database.Configurations
{
    public sealed class CourseRegistrationConfiguration : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder.HasKey(cr => cr.Id);           
            builder.Property(cr => cr.StudentId).IsRequired();
            builder.Property(cr => cr.CourseId).IsRequired();
            builder.Property(cr => cr.Session).IsRequired().HasMaxLength(9);
            builder.Property(cr => cr.Semester).IsRequired().HasMaxLength(1);
            builder.Property(cr => cr.RegistrationDate).IsRequired();
            builder.HasIndex(cr => new { cr.StudentId, cr.CourseId, cr.Session }).IsUnique();
            builder.HasOne<Student>().WithMany().HasForeignKey(cr => cr.StudentId);
            builder.HasOne<Course>().WithMany().HasForeignKey(cr => cr.CourseId);

        }
    }
}
