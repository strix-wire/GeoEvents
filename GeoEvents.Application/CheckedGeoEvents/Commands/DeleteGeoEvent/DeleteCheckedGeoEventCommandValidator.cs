using FluentValidation;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteCheckedGeoEventCommandValidator : AbstractValidator<DeleteCheckedGeoEventCommand>
    {
        public DeleteCheckedGeoEventCommandValidator()
        {
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
