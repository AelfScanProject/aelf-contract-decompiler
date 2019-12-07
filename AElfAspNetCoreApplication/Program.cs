using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AElfAspNetCoreApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(builder =>
                 {
                     builder.ClearProviders();
                     builder.AddConsole();
                     builder.SetMinimumLevel(LogLevel.Trace);
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:5566");
                    //webBuilder.UseKestrel(options => options.Listen(IPAddress.Any, 5566));
                })
                .UseAutofac();
    }
}