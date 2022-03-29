using MediatR;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventDetails
{
    //Queries. 1 - details GeoEvents, 2 - for get list GeoEvents.
    //Т.е. по UserID и Id события вернется - GeoEventDetailsVm
    public class CheckedGetGeoEventDetailsQuery : IRequest<CheckedGeoEventDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
