using System.Threading.Tasks;
using EscapeMines.Abstractions;
using EscapeMines.Services;
using EscapeMines.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EscapeMines
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<PathSetting>(hostContext.Configuration.GetSection("PathSetting"));

                    services.AddSingleton<IFileService, FileService>();
                    services.AddSingleton<IBoardService, BoardService>();
                    services.AddSingleton<IMineService, MineService>();
                    services.AddSingleton<ITurtleService, TurtleService>();
                    services.AddSingleton<IHostedService, EscapeMineHostedService>();
                })
                .ConfigureLogging((hostingContext, logging) => {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            await builder.RunConsoleAsync();
        }
    }
}
