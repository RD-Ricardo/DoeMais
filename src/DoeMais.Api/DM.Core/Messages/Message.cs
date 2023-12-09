namespace DM.Core.Messages
{
    public abstract class Message
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
