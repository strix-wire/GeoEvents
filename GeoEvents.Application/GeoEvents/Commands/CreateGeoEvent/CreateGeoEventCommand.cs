using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent
{
    //Command result
    //ONLY information what need to create GeoEvent
    //CreateGeoEventCommandHandler - LOGIC
    public class CreateGeoEventCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
