using FluentValidation;

namespace GeoEvents.Application.GeoEvents.Commands.DeleteCommand
{
    public class DeleteGeoEventCommandValidator : AbstractValidator<DeleteGeoEventCommand>
    {
        public DeleteGeoEventCommandValidator()
        {
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteGeoEventCommand => deleteGeoEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
