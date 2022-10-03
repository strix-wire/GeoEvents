using MediatR;
using System;
using System.Collections.Generic;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent
{
    //Command result
    //ONLY information what need to create GeoEvent
    //CreateGeoEventCommandHandler - LOGIC
    public class CreateCheckedGeoEventCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
