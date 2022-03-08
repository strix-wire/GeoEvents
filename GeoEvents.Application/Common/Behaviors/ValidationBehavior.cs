using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using FluentValidation;

namespace GeoEvents.Application.Common.Behaviors
{
    //Нужно, чтобы во время запросов и команд работала валидация
    //Встроим ее в pipeline медиатора.
    //Параметр request - объект запроса переданный через IMediatr.Send
    //Параметр next - асинхронное продолжение для следующего вызова в цепочке behavior
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            //Если есть хоть одна ошибка валидации => исключение ValidationException
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
