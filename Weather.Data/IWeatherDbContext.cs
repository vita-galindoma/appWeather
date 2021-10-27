using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Weather.Data
{
    public interface IWeatherDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbSet<Core.Models.Weather> Weather { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
