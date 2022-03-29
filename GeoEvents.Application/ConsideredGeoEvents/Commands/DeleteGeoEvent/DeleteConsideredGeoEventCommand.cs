using System;
using MediatR;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteConsideredGeoEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
