using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ExceptionLoggingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionLoggingMiddleware> _logger;

	public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
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
			_logger.LogError(ex, "Необроблене виключення");

			await LogToFileAsync(ex);

			throw;
		}
	}

	private async Task LogToFileAsync(Exception ex)
	{
		string logFilePath = "error_log.txt";
		string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}\n\n";
		await File.AppendAllTextAsync(logFilePath, logMessage);
	}
}
