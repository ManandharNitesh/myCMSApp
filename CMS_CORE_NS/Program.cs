using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using LoggingService;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Sinks.SystemConsole.Themes;

namespace CMS_CORE_NS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //try
                //{
                //    int zero = 0;
                //    int result = 100 / zero;
                //}
                //catch (DivideByZeroException ex)
                //{
                //    Log.Error("An error occurrred while sending the database {Error} {StackTrace} {InnerException} {Source}",
                //        ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                //}

                Log.Error("Some Error");
                Log.Fatal("Some Error");
                Log.Warning("Some Error");


            }


            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog((hostingContext,loggingConfiguration) => loggingConfiguration
                      .Enrich.FromLogContext()
                      .Enrich.WithProperty("Application", "CMS_CORE_NG")
                      .Enrich.WithProperty("MachineName", Environment.MachineName)
                      .Enrich.WithProperty("CurrentManagedThreadId", Environment.CurrentManagedThreadId)
                      .Enrich.WithProperty("OSVersion", Environment.OSVersion)
                      .Enrich.WithProperty("Version", Environment.Version)
                      .Enrich.WithProperty("UserName", Environment.UserName)
                      .Enrich.WithProperty("ProcessId", Process.GetCurrentProcess().Id)
                      .Enrich.WithProperty("ProcessName", Process.GetCurrentProcess().ProcessName)
                      .WriteTo.Console(theme: CustomConsoleTheme.VisualStudioMacLight)
                      .WriteTo.File(formatter: new CustomTextFormatter(), path: Path.Combine(hostingContext.HostingEnvironment.ContentRootPath + $"{Path.DirectorySeparatorChar}Logs{Path.DirectorySeparatorChar}", $"cms_core_ng_{DateTime.Now:yyyyMMdd}.txt"))
                     .ReadFrom.Configuration(hostingContext.Configuration)
                     //DirectorySeparatorChar based on deployed operating system will confugure  / \ path
                    );
                    webBuilder.UseStartup<Startup>();
                });
    }
}
