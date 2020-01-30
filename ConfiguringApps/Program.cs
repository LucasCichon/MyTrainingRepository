using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            return new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                //ta metoda jest używana do wczytania danych konfiguracyjnych z pliku JSON, takiego jak appsettings.json
                config.AddJsonFile("appsettings.json",
                    optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                optional: true, reloadOnChange: true);
                //ta metoda jest używana do wczytania danych konfiguracyjnych ze zmiennych środowiskowych
                config.AddEnvironmentVariables();
                if(args != null)
                {
                    //ta metoda jest używana do wczytania danych konfiguracyjnych z argumentó powłoki podanych podczas uruchomienia aplikacji
                    config.AddCommandLine(args);
                }
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(
                    hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            })
            .UseIISIntegration()
            .UseDefaultServiceProvider((context, options) =>
            {
                options.ValidateScopes =
                context.HostingEnvironment.IsDevelopment();
            })
            .UseStartup(nameof(ConfiguringApps))
            .Build();
        }
    }
}
