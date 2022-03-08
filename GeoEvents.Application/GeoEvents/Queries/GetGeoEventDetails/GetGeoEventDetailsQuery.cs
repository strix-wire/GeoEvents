using MediatR;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails
{
    //Queries. 1 - details GeoEvents, 2 - for get list GeoEvents.
    public class GetGeoEventDetailsQuery : IRequest<GeoEventDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
