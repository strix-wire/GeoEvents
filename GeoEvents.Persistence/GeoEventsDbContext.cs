using GeoEvents.Application.Interfaces;
using GeoEvents.Domain;
using GeoEvents.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoEvents.Persistence
{
    public class GeoEventsDbContext : IdentityDbContext, IGeoEventsDbContext
    {
        public DbSet<GeoEvent> GeoEvents { get; set; }
        
        public GeoEventsDbContext(DbContextOptions<GeoEventsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GeoEventConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
