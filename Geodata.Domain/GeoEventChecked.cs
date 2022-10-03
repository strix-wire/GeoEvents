using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Domain
{
    public class GeoEventChecked
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
