using Scalar.AspNetCore;
using System.Reflection;
using Uni.Web.API;
using Uni.Web.API.Common.Endpoints;
using Uni.Web.API.Common.Extensions;
using Web.Api.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
//builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

app.MapEndpoints(); // Map all endpoints from the assembly

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    //app.UseSwagger();
    //app.UseSwaggerUI();

    await app.ApplyMigrationsAsync();
    await app.ApplySeedingsAsync();
}

app.UseHttpsRedirection();

//app.Run();

await app.RunAsync();

// REMARK: Required for functional and integration tests to work.
namespace Uni.Web.API
{
    public partial class Program;
}