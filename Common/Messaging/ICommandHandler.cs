namespace Uni.Web.API.Common.Messaging;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<ServiceResponse> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<ServiceResponse<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}
