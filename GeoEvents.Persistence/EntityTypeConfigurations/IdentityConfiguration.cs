using Microsoft.EntityFrameworkCore;
using GeoEvents.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoEvents.Persistence.EntityTypeConfigurations
{
    public class IdentityConfiguration : IEntityTypeConfiguration<GeoEventConsidered>
    {
        public void Configure(EntityTypeBuilder<GeoEventConsidered> builder)
        {
            
        }
    }
}
