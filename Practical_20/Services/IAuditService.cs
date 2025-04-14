namespace Practical_20.Services
{
    public interface IAuditService
    {
        Task LogEventAsync(string eventName, string username, string details);
    }
}
