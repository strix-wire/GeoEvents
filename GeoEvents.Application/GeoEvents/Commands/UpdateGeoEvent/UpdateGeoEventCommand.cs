using MediatR;

namespace GeoEvents.Application.GeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateGeoEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
