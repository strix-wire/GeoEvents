using Geodata.Persistence;
using GeoEvents.Persistence;

namespace GeoEvents.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //    .WriteTo.File("GeoEventsWebAppLog-.txt", rollingInterval:
            //        RollingInterval.Day)
            //    .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    //Call initialize DB
                    var context = serviceProvider.GetRequiredService<GeodataDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    //Если база не была успешно создана
                    //Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
