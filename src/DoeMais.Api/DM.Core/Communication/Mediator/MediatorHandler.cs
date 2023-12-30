using DM.Core.Messages;
using DM.Core.Messages.CommonMessages.Notifications;
using DM.Core.WebApi;
using MediatR;

namespace DM.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediador;
        public MediatorHandler(IMediator mediador)
        {
            _mediador = mediador;
        }

        public Task<RequestResult<TResult>> PublicarComando<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>
        {
            return _mediador.Send(command);
        }

        public Task<RequestResult<TResult>> PublicarConsulta<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>
        {
            return _mediador.Send(query);
        }

        public Task PublicarDomainEvent<TEvent>(TEvent evento) where TEvent : Event
        {
            return _mediador.Publish(evento);
            
        }

        public Task PublicarNotificacao<TNotification>(TNotification notification) where TNotification : DomainNotification
        {
            return _mediador.Publish(notification);
        }
    }
}
