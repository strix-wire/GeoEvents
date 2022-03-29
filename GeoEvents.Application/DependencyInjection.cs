using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using GeoEvents.Application.Common.Behaviors;

namespace GeoEvents.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            //Добавляем валидатор из сборки
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            //Регистрируем PipelineBehavior
            //ТУТ ОШИБКА, НУЖНО РАЗОБРАТЬСЯ
            //services.AddTransient(typeof(IPipelineBehavior<,>),
            //    typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
