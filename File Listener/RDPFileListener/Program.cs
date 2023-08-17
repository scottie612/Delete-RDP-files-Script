
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using RDPFileListener;
using System.Runtime;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
        .UseWindowsService(options =>
        {
            options.ServiceName = "File Listener";
        })
        .ConfigureServices((hostContext, services) =>
        {
            services.AddOptions<Settings>().Bind(hostContext.Configuration.GetSection("FileOptions"));
            services.AddHostedService<Worker>();
            services.AddSingleton<IWatcher, Watcher>();
        })
        .Build()
        .RunAsync();

     
    }
}