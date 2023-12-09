using DM.Core.WebApi;
using MediatR;

namespace DM.Core.Messages.Handlers
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, RequestResult<TResult>> where TCommand : Command<TResult>
    {
        public abstract Task<RequestResult<TResult>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
