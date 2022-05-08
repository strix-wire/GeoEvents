using GeoEvents.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeoEvents.Application.Interfaces
{
    //Interface - partial application, but implementation - outside
    public interface IGeoEventsDbContext
    {
        //DbSet - collection all entities in context

        //Подать заявку на рассмотрение
        DbSet<GeoEventConsidered> ConsideredGeoEvents { get; set; }
        //Проверенные и одобренные события
        DbSet<GeoEventChecked> CheckedGeoEvents { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
