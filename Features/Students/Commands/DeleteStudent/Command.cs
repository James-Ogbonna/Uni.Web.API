using Uni.Web.API.Common.Messaging;

namespace Uni.Web.API.Features.Students.Commands.DeleteStudent;

public sealed record Command(Guid StudentId) : ICommand;
