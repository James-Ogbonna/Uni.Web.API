using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Database;

namespace Web.Api.Common.Extensions;

public static class MigrationExtensions
{
    public static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
    {
        try
        {
             using IServiceScope scope = app.ApplicationServices.CreateScope();

             using ApplicationDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

           await  dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
