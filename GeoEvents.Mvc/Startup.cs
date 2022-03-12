using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using GeoEvents.Application;
using GeoEvents.Persistence;
using GeoEvents.Mvc.Middleware;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(config =>
            {
                //Get information about current assembly in progress
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IGeoEventsDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            //Разрешает все корсы, лучше так не делать
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            //services.AddAuthentication(config =>
            //{
            //    config.DefaultAuthenticateScheme =
            //        JwtBearerDefaults.AuthenticationScheme;
            //    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
                //.AddJwtBearer("Bearer", options =>
                //{
                //    options.Authority = "https://localhost:44386/";
                //    options.Audience = "GeoEventsWebAPI";
                //    options.RequireHttpsMetadata = false;
                //});

            //services.AddVersionedApiExplorer(options =>
            //    options.GroupNameFormat = "'v'VVV");
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
            //        ConfigureSwaggerOptions>();
            //services.AddSwaggerGen();
            //services.AddApiVersioning();

            //services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseSwagger();
            //app.UseSwaggerUI(config =>
            //{
            //    foreach (var description in provider.ApiVersionDescriptions)
            //    {
            //        config.SwaggerEndpoint(
            //            $"/swagger/{description.GroupName}/swagger.json",
            //            description.GroupName.ToUpperInvariant());
            //        config.RoutePrefix = string.Empty;
            //    }
            //});
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
