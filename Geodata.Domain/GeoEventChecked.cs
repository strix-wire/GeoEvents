using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Domain
{
    public class GeoEventChecked
    {
        //Id event
        public Guid Id { get; set; }
        //Id user which created event
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
