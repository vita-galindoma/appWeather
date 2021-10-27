using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Refit;
using Weather.Core.Services;

namespace Weather.Scraper
{
    public class WeatherDataScraper
    {
        private readonly IDbService _service;
        public WeatherDataScraper(IDbService dbService)
        {
            _service = dbService;
        }

        [FunctionName("WeatherDataScraper")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log) //"0 */15 * * * *"
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var weatherServiceApi = RestService.For<IWeatherService>("https://api.openweathermap.org", new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            });
            var weatherInfo = await weatherServiceApi.GetWeather();

            log.LogInformation($" {JsonConvert.SerializeObject(weatherInfo)}");
        }
    }
}
