using System;
using MediatR;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteCheckedGeoEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
