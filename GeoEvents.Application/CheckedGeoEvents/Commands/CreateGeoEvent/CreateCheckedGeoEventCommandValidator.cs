using FluentValidation;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent
{
    public class CreateUserCommandValidator : AbstractValidator<CreateCheckedGeoEventCommand>
    {
        public CreateUserCommandValidator()
        {
            //Длина заголовка GeoEvent не более 250 символов.
            //ID пользователя не должен быть пустым Guid.
            RuleFor(createGeoEventCommand =>
                createGeoEventCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createGeoEventCommand =>
                createGeoEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
