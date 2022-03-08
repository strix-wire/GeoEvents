using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Persistence
{
    public static class DependencyInjection
    {
        //Метод расширения для добавления контекста БД в веб приложение и его регистрация
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<GeoEventsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IGeoEventsDbContext>(provider => provider.GetService<GeoEventsDbContext>());
            return services;
        }
    }
}
