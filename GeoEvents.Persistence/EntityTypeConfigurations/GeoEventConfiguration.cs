using Microsoft.EntityFrameworkCore;
using GeoEvents.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoEvents.Persistence.EntityTypeConfigurations
{
    //This class need to decrease size method "OnModelCreating"
    //If in project will appear new entities, then will be convenient
    //to expand configuration
    public class GeoEventConfiguration : IEntityTypeConfiguration<GeoEventConsidered>
    {
        public void Configure(EntityTypeBuilder<GeoEventConsidered> builder)
        {
            //Id - primary key
            builder.HasKey(geoEvent => geoEvent.Id);
            //Id - unique
            builder.HasIndex(geoEvent => geoEvent.Id).IsUnique();
        }
    }
}
