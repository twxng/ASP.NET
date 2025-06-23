using System.Diagnostics;
using Lr9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Lr9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "iPhone 15", Price = 39999 },
                new Product { ID = 2, Name = "MacBook Air", Price = 59999 },
                new Product { ID = 3, Name = "iPad Pro", Price = 29999 }
            };
            ViewBag.Products = products;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Weather(string city = "Kyiv")
        {
            var apiKey = _config["Weather:ApiKey"] ?? "";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=ua";
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            dynamic weatherData = JsonConvert.DeserializeObject(response);
            var weather = new WeatherInfo
            {
                City = weatherData.name,
                Description = weatherData.weather[0].description,
                Temperature = weatherData.main.temp,
                Icon = weatherData.weather[0].icon,
                Main = weatherData.weather[0].main
            };
            return PartialView("~/Views/Shared/_WeatherWidget.cshtml", weather);
        }
    }
}
