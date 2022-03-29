using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails
{
    public class ConsideredGetGeoEventDetailsQueryValidator : AbstractValidator<ConsideredGetGeoEventDetailsQuery>
    {
        public ConsideredGetGeoEventDetailsQueryValidator()
        {
            RuleFor(geoEvent => geoEvent.Id).NotEqual(Guid.Empty);
            RuleFor(geoEvent => geoEvent.UserId).NotEqual(Guid.Empty);
        }
    }
}
