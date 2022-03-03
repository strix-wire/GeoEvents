using GeoEvents.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeoEvents.Application.Interfaces
{
    //Interface - partial application, but implementation - outside
    public interface IGeoEventsDbContext
    {
        //DbSet - collection all entities in context
        DbSet<GeoEvent> GeoEvent { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
