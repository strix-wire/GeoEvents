using FluentValidation;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteConsideredGeoEventCommandValidator : AbstractValidator<DeleteConsideredGeoEventCommand>
    {
        public DeleteConsideredGeoEventCommandValidator()
        {
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
