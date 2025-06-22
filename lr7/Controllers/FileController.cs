using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace lr7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) fileName = "result.txt";
            var content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            var bytes = Encoding.UTF8.GetBytes(content);
            return File(bytes, "text/plain", fileName.EndsWith(".txt") ? fileName : fileName + ".txt");
        }
    }
} 