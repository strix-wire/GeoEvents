using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Persistence
{
    //Check at start application - is the database created. If not - will created.
    public class DbInitializer
    {
        public static void Initialize(GeoEventsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
