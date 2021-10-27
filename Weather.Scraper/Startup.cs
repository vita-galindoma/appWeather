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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<WeatherDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WeatherDbContext")));
            builder.Services.AddScoped<IWeatherDbContext, WeatherDbContext>();
            builder.Services.AddScoped<IDbService, DbService>();
            builder.Services.AddRefitClient<IWeatherService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.openweathermap.org"));
        }
    }
}
