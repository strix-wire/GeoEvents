using MediatR;
using System;
using System.Collections.Generic;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.CreateGeoEvent
{
    //Command result
    //ONLY information what need to create GeoEvent
    //CreateGeoEventCommandHandler - LOGIC
    public class CreateConsideredGeoEventCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
