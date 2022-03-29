using FluentValidation;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateCheckedGeoEventCommandValidator : AbstractValidator<UpdateCheckedGeoEventCommand>
    {
        public UpdateCheckedGeoEventCommandValidator()
        {
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateGeoEventCommand => updateGeoEventCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}
