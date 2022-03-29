using MediatR;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQuery : IRequest<ConsideredGeoEventListVm>
    {
        public Guid UserId { get; set; }
    }
}
