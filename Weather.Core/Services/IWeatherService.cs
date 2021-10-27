using System.Threading.Tasks;
using Refit;

namespace Weather.Core.Services
{
    public interface IWeatherService
    {
        [Get("/data/2.5/weather?q=London,uk&APPID=d8a271206eb42201aff61342cecec6ce")]
        Task<Models.Weather> GetWeather();
    }
}