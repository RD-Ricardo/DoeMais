using MediatR;

namespace DM.Core.Messages.Handlers
{
    public interface IEntityEventHandler<TEvent, TEntity> : INotificationHandler<TEvent> where TEvent : Event
    {
    }
}
