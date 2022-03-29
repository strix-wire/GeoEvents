using FluentValidation;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQueryValidator : AbstractValidator<ConsideredGetGeoEventListQuery>
    {
        public ConsideredGetGeoEventListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
