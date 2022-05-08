using Bluestone.Infrastructure.Logging;
using Bluestone.WebAPI.ConfigurationOptions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bluestone.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseBluestoneLogger(configuration =>
                {
                    var appSettings = new AppSettings();
                    configuration.Bind(appSettings);
                    return appSettings.Logging;
                });
    }
}
