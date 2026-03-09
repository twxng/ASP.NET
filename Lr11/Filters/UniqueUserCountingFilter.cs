using System.Collections.Concurrent;
using Lr11.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lr11.Filters
{
    /// <summary>
    /// Фільтр, який рахує кількість унікальних користувачів,
    /// що звернулися до вебзастосунку, та записує це число у файл.
    /// </summary>
    public class UniqueUserCountingFilter : ActionFilterAttribute
    {
        private static readonly ConcurrentDictionary<string, byte> UniqueUsers = new();
        private readonly ILogService _logService;
        private const string LogFileName = "unique_users_count.txt";

        public UniqueUserCountingFilter(ILogService logService)
        {
            _logService = logService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var userIdentifier = GetUserIdentifier(request);

            var wasAdded = UniqueUsers.TryAdd(userIdentifier, 0);

            if (wasAdded)
            {
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var logEntry =
                    $"[{timestamp}] New unique user detected. Total unique users: {UniqueUsers.Count}";

                _logService.AppendLine(LogFileName, logEntry);
            }

            base.OnActionExecuting(context);
        }

        private static string GetUserIdentifier(HttpRequest request)
        {
            var ipAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var userAgent = request.Headers["User-Agent"].ToString();

            var combined = $"{ipAddress}|{userAgent}";
            return combined.GetHashCode().ToString();
        }
    }
}

