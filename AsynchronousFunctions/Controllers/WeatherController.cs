using AsynchronousFunctions.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsynchronousFunctions.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _weatherService.GetWeatherAsync();
            ViewBag.Weather = data;
            return View();
        }
    }
}
