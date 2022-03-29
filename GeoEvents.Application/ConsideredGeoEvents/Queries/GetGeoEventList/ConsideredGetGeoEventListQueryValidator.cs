using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQueryValidator : AbstractValidator<ConsideredGetGeoEventListQuery>
    {
        public ConsideredGetGeoEventListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
