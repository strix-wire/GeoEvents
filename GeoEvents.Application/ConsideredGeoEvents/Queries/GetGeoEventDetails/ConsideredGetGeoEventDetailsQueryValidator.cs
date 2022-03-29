using FluentValidation;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventDetails
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
