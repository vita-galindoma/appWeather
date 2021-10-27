using Microsoft.EntityFrameworkCore;

namespace Weather.Data
{
    public class WeatherDbContext : DbContext, IWeatherDbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Models.Weather> Weather { get; set; }

    }
}

