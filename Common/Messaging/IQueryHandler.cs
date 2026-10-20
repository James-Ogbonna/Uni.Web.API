namespace Uni.Web.API.Common.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<ServiceResponse<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
