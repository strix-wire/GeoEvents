using MediatR;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQuery : IRequest<ConsideredGeoEventListVm>
    {
        public Guid UserId { get; set; }
    }
}
