using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Weather.Core.Services;
using Weather.Data;
using Weather.Services;

[assembly: FunctionsStartup(typeof(Weather.Scraper.Startup))]
namespace Weather.Scraper
{
    
    public class Startup : FunctionsStartup
    {

        public IConfiguration Configuration { get; private set; }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            Configuration = builder.GetContext().Configuration;
            builder.Services.AddDbContext<WeatherDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WeatherDbContext")));
            builder.Services.AddScoped<IWeatherDbContext, WeatherDbContext>();
            builder.Services.AddScoped<IDbService, DbService>();
            builder.Services.AddRefitClient<IWeatherService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.openweathermap.org"));
        }
    }
}
