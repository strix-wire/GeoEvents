using MediatR;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    public class CheckedGetGeoEventListQuery : IRequest<CheckedGeoEventListVm>
    {
        public Guid UserId { get; set; }
    }
}
