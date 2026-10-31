using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudentByRegNumber;

public sealed record Query(string RegNumber) : IQuery<Response>;


