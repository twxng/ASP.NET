using System;

namespace Lr11.Services
{
    /// <summary>
    /// Абстракція для запису логів у файли.
    /// Дозволяє фільтрам дотримуватися принципу DIP (SOLID).
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Додати один рядок до вказаного файлу журналу.
        /// </summary>
        /// <param name="fileName">Ім'я файлу журналу (без шляху).</param>
        /// <param name="line">Текст рядка.</param>
        void AppendLine(string fileName, string line);
    }
}

