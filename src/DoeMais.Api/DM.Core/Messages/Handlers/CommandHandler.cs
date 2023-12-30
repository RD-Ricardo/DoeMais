using DM.Core.WebApi;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DM.Core.Messages.Handlers
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, RequestResult<TResult>> where TCommand : Command<TResult>
    {
        public abstract Task<RequestResult<TResult>> Handle(TCommand request, CancellationToken cancellationToken);

        public RequestResult<TResult> Sucesso()
        {
            return new RequestResult<TResult>(true);
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
