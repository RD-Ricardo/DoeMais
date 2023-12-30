using MediatR;

namespace DM.Core.Messages.CommonMessages.Notifications
{
    public class  DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification>  ObterNotificao() 
            => _notifications;

        public virtual bool TemNotificao() 
            => ObterNotificao().Any();
    }
}
