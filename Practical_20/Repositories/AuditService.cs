using Practical_20.Data;
using Practical_20.Logging;
using Practical_20.Services;

namespace Practical_20.Repositories
{
    public class AuditService : IAuditService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AuditService> _logger;

        public AuditService(ApplicationDbContext context, ILogger<AuditService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task LogEventAsync(string eventName, string username, string details)
        {
            var log = new AuditLog
            {
                Event = eventName,
                Username = username,
                Details = details
            };

            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"[AuditLog] {eventName} by {username}: {details}");
        }
    }

}
