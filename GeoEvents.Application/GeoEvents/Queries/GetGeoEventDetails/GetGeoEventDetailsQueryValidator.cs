using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails
{
    public class GetGeoEventDetailsQueryValidator : AbstractValidator<GetGeoEventDetailsQuery>
    {
        public GetGeoEventDetailsQueryValidator()
        {
            RuleFor(geoEvent => geoEvent.Id).NotEqual(Guid.Empty);
            RuleFor(geoEvent => geoEvent.UserId).NotEqual(Guid.Empty);
        }
    }
}
