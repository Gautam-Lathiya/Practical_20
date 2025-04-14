using System.Net;

namespace Practical_20.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error",
                    Details = ex.Message,
                    WasGlobalExceptionCaught = "Yes, Gautam. It was caught globally."
                };

                var json = System.Text.Json.JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }

}
