using DM.Core.Messages;
using DM.Core.Messages.CommonMessages.DomainEvents;
using DM.Core.Messages.CommonMessages.Notifications;
using DM.Core.WebApi;

namespace DM.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<RequestResult<TResult>> PublicarComando<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;
        Task<RequestResult<TResult>> PublicarConsulta<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>;
        Task PublicarNotificacao<TNotification>(TNotification notification) where TNotification : DomainNotification;
        Task PublicarDomainEvent<TEvent>(TEvent evento) where TEvent : Event;
    }
}
