using MediatR;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateCheckedGeoEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
