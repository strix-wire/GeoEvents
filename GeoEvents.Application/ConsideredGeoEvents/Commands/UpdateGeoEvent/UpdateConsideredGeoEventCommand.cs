using MediatR;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateConsideredGeoEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
