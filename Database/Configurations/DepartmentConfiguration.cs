using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Departments;
using Uni.Web.API.Features.Schools;

namespace Uni.Web.API.Database.Configurations
{
    public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id); //Primary key
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.SchoolId).IsRequired();
            builder.HasOne<School>().WithMany().HasForeignKey(d => d.SchoolId);
        }
    }
}
