using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateGeoEventCommandValidator : AbstractValidator<UpdateGeoEventCommand>
    {
        public UpdateGeoEventCommandValidator()
        {
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}
