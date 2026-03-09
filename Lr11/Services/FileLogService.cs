using System;
using System.Collections.Concurrent;

namespace Lr11.Services
{
    /// <summary>
    /// Сервіс для потокобезпечного запису логів у текстові файли.
    /// Відповідає за єдиний обов'язок — роботу з файловою системою.
    /// </summary>
    public class FileLogService : ILogService
    {
        private readonly string _logsDirectory;
        private static readonly ConcurrentDictionary<string, object> _fileLocks = new();

        public FileLogService()
        {
            _logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(_logsDirectory);
        }

        public void AppendLine(string fileName, string line)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Ім'я файлу журналу не може бути порожнім.", nameof(fileName));
            }

            var filePath = Path.Combine(_logsDirectory, fileName);
            var fileLock = _fileLocks.GetOrAdd(filePath, _ => new object());

            lock (fileLock)
            {
                File.AppendAllText(filePath, line + Environment.NewLine);
            }
        }
    }
}

