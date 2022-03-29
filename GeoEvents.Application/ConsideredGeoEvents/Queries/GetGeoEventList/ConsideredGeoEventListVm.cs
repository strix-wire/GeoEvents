using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGeoEventListVm
    {
        public IList<ConsideredGeoEventLookupDto> GeoEvents { get; set; }
    }
}
