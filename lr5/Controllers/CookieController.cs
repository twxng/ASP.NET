using Microsoft.AspNetCore.Mvc;

public class CookieController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SetCookie(string value, DateTime expirationDate)
    {
        // Симуляція помилки для тестування
        if (value == "test_error")
        {
            throw new Exception("Тестове виключення при встановленні cookie");
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Значення Cookie не може бути порожнім", nameof(value));
        }

        Response.Cookies.Append("CustomCookie", value, new CookieOptions
        {
            Expires = expirationDate
        });
        return RedirectToAction("CheckCookie");
    }

    public IActionResult CheckCookie()
    {
        var cookieValue = Request.Cookies["CustomCookie"];
        ViewBag.CookieValue = cookieValue;
        return View();
    }
}
