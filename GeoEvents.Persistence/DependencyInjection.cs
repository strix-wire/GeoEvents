using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Interfaces;
using Geodata.Application.Interfaces;
using Geodata.Persistence;

namespace GeoEvents.Persistence
{
    public static class DependencyInjection
    {
        //Метод расширения для добавления контекста БД в веб приложение и его регистрация
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<GeodataDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                
            });
            services.AddScoped<IGeodataDbContext>(provider => provider.GetService<GeodataDbContext>());
            services.AddScoped<IGeoEventsDbContext>(provider => provider.GetService<GeoEventsDbContext>());
            return services;
        }
    }
}
