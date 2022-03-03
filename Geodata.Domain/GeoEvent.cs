using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geodata.Domain
{
    public class GeoEvent
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        //
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
