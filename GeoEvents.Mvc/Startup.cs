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
using Microsoft.AspNetCore.Identity;
using GeoEvents.Persistence.IdentityEF;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GeoEvents.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        //private IHttpContextAccessor httpContextAccessor;

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
          //  this.httpContextAccessor = httpContextAccessor;
        } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<MyIdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<GeoEventsDbContext>();
            //services.AddHttpContextAccessor();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Определяем параметры пароля
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddAutoMapper(config =>
            {
                //Get information about current assembly in progress
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IGeoEventsDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllersWithViews();

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

            //services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //accessor.HttpContext.RequestServices;
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
