using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent
{
    public class CreateGeoEventCommandValidator : AbstractValidator<CreateGeoEventCommand>
    {
        public CreateGeoEventCommandValidator()
        {
            //Длина заголовка заметки не более 250 символов.
            //ID пользователя не должен быть пустым Guid.
            RuleFor(createGeoEventCommand =>
                createGeoEventCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createGeoEventCommand =>
                createGeoEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
