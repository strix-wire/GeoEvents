using FluentValidation;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    public class CheckedGetGeoEventListQueryValidator : AbstractValidator<CheckedGetGeoEventListQuery>
    {
        public CheckedGetGeoEventListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
