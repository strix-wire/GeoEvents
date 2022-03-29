using GeoEvents.Application.Interfaces;
using GeoEvents.Domain;
using GeoEvents.Persistence.EntityTypeConfigurations;
using GeoEvents.Persistence.IdentityEF;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoEvents.Persistence
{
    public class GeoEventsDbContext : IdentityDbContext<MyIdentityUser>, IGeoEventsDbContext
    {
        public DbSet<GeoEvent> ConsideredGeoEvents { get; set; }
        public DbSet<GeoEvent> CheckedGeoEvents { get; set; }

        public GeoEventsDbContext(DbContextOptions<GeoEventsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GeoEventConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
