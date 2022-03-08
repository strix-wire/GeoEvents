using System;
using MediatR;

namespace GeoEvents.Application.GeoEvents.Commands.DeleteCommand
{
    public class DeleteGeoEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
