using MediatR;

namespace DM.Core.Messages.Handlers
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : Event
    {
    }
}
