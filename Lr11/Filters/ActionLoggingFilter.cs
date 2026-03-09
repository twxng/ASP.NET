using Lr11.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lr11.Filters
{
    /// <summary>
    /// Фільтр дії, який записує у файл ім'я методу дії та час звернення.
    /// </summary>
    public class ActionLoggingFilter : ActionFilterAttribute
    {
        private readonly ILogService _logService;
        private const string LogFileName = "action_logs.txt";

        public ActionLoggingFilter(ILogService logService)
        {
            _logService = logService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName ?? "Unknown Action";
            var controllerName = context.Controller.GetType().Name;
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var logEntry = $"[{timestamp}] Controller: {controllerName}, Action: {actionName}";

            _logService.AppendLine(LogFileName, logEntry);

            base.OnActionExecuting(context);
        }
    }
}
