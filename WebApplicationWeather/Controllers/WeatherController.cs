using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Refit;
using Weather.Core.Services;

namespace WebApplicationWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IDbService _context;

        public WeatherController(IDbService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var weatherServiceApi = RestService.For<IWeatherService>("https://api.openweathermap.org", new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            });
            var weatherInfo = await weatherServiceApi.GetWeather();
            _context.Create(weatherInfo);
            return View(weatherInfo);
        }

    }
}
