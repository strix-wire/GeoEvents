using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class GetGeoEventListQueryValidator : AbstractValidator<GetGeoEventListQuery>
    {
        public GetGeoEventListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
