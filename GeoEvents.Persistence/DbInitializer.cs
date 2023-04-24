using Geodata.Persistence;

namespace GeoEvents.Persistence
{
    //Check at start application - is the database created. If not - will created.
    public class DbInitializer
    {
        public static void Initialize(GeodataDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
