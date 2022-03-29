using FluentValidation;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventDetails
{
    public class CheckedGetGeoEventDetailsQueryValidator : AbstractValidator<CheckedGetGeoEventDetailsQuery>
    {
        public CheckedGetGeoEventDetailsQueryValidator()
        {
            RuleFor(geoEvent => geoEvent.Id).NotEqual(Guid.Empty);
            RuleFor(geoEvent => geoEvent.UserId).NotEqual(Guid.Empty);
        }
    }
}
