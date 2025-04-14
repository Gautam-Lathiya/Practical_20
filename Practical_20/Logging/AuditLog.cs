namespace Practical_20.Logging
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public string Username { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
