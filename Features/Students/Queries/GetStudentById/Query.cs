using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Queries.GetStudentById;

public sealed record Query(Guid StudentId) : IQuery<Response>;


