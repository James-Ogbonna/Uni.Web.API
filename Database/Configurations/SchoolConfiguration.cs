using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Web.API.Features.Schools;

namespace Uni.Web.API.Database.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(s => s.Id); //Primary key
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100); //E.g. School of Information and Communication Technology

        }
    }
}
