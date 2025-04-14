using Microsoft.AspNetCore.Mvc;
using Practical_20.Services;

namespace Practical_20.Controllers
{
    public class LoggingController : Controller
    {
        private readonly IAuditService _auditService;

        public LoggingController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            await _auditService.LogEventAsync("User Created", $"{name}", $"User {name} created.");
            return RedirectToAction("Index");
        }
    }
}
