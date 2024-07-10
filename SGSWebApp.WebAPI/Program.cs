using SGSWebApp.Application.Common.Helpers;
using SGSWebApp.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        MapperInitializer.Configure();
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}