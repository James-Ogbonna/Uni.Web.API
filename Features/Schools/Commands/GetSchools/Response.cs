namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

public sealed record Response(
    Guid Id,
    string Name,
    string Abbr);
