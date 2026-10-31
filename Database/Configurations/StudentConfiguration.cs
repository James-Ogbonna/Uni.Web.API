using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Departments;
using Uni.Web.API.Features.Students;

namespace Uni.Web.API.Database.Configurations;
public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.RegNumber).IsUnique();
        builder.Property(s => s.RegNumber).IsRequired().HasMaxLength(11);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(20);
        builder.Property(s => s.DateOfBirth).IsRequired();
        builder.Property(s => s.Email).IsRequired().HasMaxLength(70);
        // onwuegbuchulam.ifesinachukwubia@uniilorin.edu.ng
        builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(11);        
        builder.Property(s => s.EntrySession).IsRequired().HasMaxLength(9);
        builder.Property(s => s.CurrentLevel).IsRequired();
        builder.Property(s => s.DepartmentId).IsRequired();
        builder.HasOne<Department>().WithMany().HasForeignKey(s => s.DepartmentId);
    }
}
