using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Departments;
using Uni.Web.API.Features.Schools;

namespace Uni.Web.API.Database.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Abbr).HasMaxLength(4);
        builder.HasOne<School>().WithMany().HasForeignKey(d => d.SchoolId);

    }
}