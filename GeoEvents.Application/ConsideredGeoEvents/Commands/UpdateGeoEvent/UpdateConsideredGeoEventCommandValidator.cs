using FluentValidation;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateConsideredGeoEventCommandValidator : AbstractValidator<UpdateConsideredGeoEventCommand>
    {
        public UpdateConsideredGeoEventCommandValidator()
        {
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}
