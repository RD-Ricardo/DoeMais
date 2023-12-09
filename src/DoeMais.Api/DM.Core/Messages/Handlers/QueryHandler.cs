using DM.Core.WebApi;
using MediatR;

namespace DM.Core.Messages.Handlers
{
    public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<TQuery, RequestResult<TResult>> where TQuery : Query<TResult>
    {
        public abstract Task<RequestResult<TResult>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
