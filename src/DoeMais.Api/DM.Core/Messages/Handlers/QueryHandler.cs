using DM.Core.WebApi;
using MediatR;

namespace DM.Core.Messages.Handlers
{
    public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<TQuery, RequestResult<TResult>> where TQuery : Query<TResult>
    {
        public abstract Task<RequestResult<TResult>> Handle(TQuery request, CancellationToken cancellationToken);

        public RequestResult<bool> Sucesso()
        {
            return new RequestResult<bool>(true);
        }

        public RequestResult<TResult> Sucesso(TResult result)
        {
            return new RequestResult<TResult>(sucesso: true, mensagemErro: null, result);
        }

        public RequestResult<TResult> Falha(List<string> mensagens)
        {
            return new RequestResult<TResult>(false, mensagens);
        }

        public RequestResult<TResult> Falha(string error)
        {
            return new RequestResult<TResult>(false, new List<string>() { error });
        }
    }
}
