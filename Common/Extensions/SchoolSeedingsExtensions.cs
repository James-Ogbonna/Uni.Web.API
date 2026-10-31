using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Uni.Web.API.Features.Departments;
using Uni.Web.API.Features.Schools;
using Uni.Web.API.Database;

namespace Uni.Web.API.Common.Extensions;

public static class SchoolSeedingsExtensions
{
    public static async Task ApplySeedingsAsync(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (await dbContext.Schools.AnyAsync()) { return; }

        var json = await  File.ReadAllTextAsync("Database/SeedData/schools.json");

        var schoolSeeds = JsonSerializer.Deserialize<List<SchoolSeed>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (schoolSeeds is null || schoolSeeds.Count == 0)
            return;

        var schools = new List<School>();
        var departments = new List<Department>();

        foreach (var schoolSeed in schoolSeeds)
        {
            var school = new School
            {
                Id = Guid.NewGuid(),
                Name = schoolSeed.Name,
                Abbr = schoolSeed.Abbr
            };

            schools.Add(school);

            foreach (var departmentSeed in schoolSeed.Departments)
            {
                departments.Add(new Department
                {
                    Id = Guid.NewGuid(),
                    Name = departmentSeed.Name,
                    Abbr = departmentSeed.Abbr,
                    SchoolId = school.Id
                });
            }
        }

        await dbContext.Schools.AddRangeAsync(schools);
        await dbContext.Departments.AddRangeAsync(departments);
        await dbContext.SaveChangesAsync();
    }
}

public sealed class SchoolSeed
{
    public string Name { get; set; } = string.Empty;
    public string Abbr { get; set; } = string.Empty;
    public List<DepartmentSeed> Departments { get; set; } = [];
}

public sealed class DepartmentSeed
{
    public string Name { get; set; } = string.Empty;
    public string Abbr { get; set; } = string.Empty;
}