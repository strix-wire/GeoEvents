using MediatR;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class GetGeoEventListQuery : IRequest<GeoEventListVm>
    {
        public Guid UserId { get; set; }
    }
}
