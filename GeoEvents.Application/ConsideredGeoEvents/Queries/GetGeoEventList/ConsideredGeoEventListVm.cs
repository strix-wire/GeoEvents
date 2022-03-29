using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGeoEventListVm
    {
        public IList<ConsideredGeoEventLookupDto> GeoEvents { get; set; }
    }
}
