using MediatR;

namespace DM.Core.Messages
{
    public abstract class Event : Message, INotification
    {
    }
}
