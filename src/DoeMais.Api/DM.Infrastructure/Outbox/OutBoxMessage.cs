namespace DM.Infrastructure.Data.Outbox
{
    public class OutBoxMessage
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string TypeFullName { get; set; } = string.Empty;
        public string  Content { get; set; } = string.Empty;
        public DateTime OccurrendOnUtc { get; set; }
        public DateTime? ProcessedOnUtc { get; set; }
        public string? Error { get; set; }
    }
}
