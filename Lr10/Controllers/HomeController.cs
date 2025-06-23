using System.Diagnostics;
using Lr10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lr10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.Products = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Lr10.Models.RegistrationViewModel model)
        {
            ViewBag.Products = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
            if (ModelState.IsValid)
            {
                // Тут можна додати логіку збереження заявки
                TempData["Success"] = "Ваша заявка успішно надіслана!";
                return RedirectToAction("Register");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
