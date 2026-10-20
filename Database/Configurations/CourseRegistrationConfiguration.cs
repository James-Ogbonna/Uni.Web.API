using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.CourseRegistrations;
using Uni.Web.API.Features.Courses;
using Uni.Web.API.Features.DepartmentalCourse;
using Uni.Web.API.Features.Students;

namespace Uni.Web.API.Database.Configurations
{
    public class CourseRegistrationConfiguration : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.StudentId).IsRequired();
            builder.Property(cr => cr.CourseId).IsRequired();
            builder.Property(cr => cr.Session).IsRequired().HasMaxLength(9); // 2023-2024
            builder.Property(cr => cr.Semester).IsRequired();
            //builder.Property(cr => cr.RegistrationDate).IsRequired();
            builder.HasOne<Student>().WithMany().HasForeignKey(cr => cr.StudentId);
            builder.HasOne<Course>().WithMany().HasForeignKey(cr =>  cr.CourseId);
        }
    }
}
