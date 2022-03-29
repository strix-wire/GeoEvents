using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    public class CheckedGeoEventListVm
    {
        public IList<CheckedGeoEventLookupDto> GeoEvents { get; set; }
    }
}
