#define V1

using System;
using System.Threading.Tasks;
using CommunityToolkit.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsAppSdkHostWithBrowser;

public static partial class Program
{
#if V1
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = new WindowsAppSdkHostBuilder<App>();

        builder.ConfigureServices(
            (_, collection) =>
            {
                // If your main Window is named differently, change it here.
                collection.AddSingleton<MainWindow>();
            }
        );

        var app = builder.Build();

        app.StartAsync().GetAwaiter().GetResult();
    }
#elif V2
    [STAThread]
    public async static Task Main(string[] args) // <- only change *async Task*
    {
        var builder = new WindowsAppSdkHostBuilder<App>();

        builder.ConfigureServices(
            (_, collection) =>
            {
                // If your main Window is named differently, change it here.
                collection.AddSingleton<MainWindow>();
            }
        );

        var app = builder.Build();

        app.StartAsync().GetAwaiter().GetResult();
    }
#elif V3
    [STAThread]
    public async static Task Main(string[] args) // <- this like in V2 and ...
    {
        var builder = new WindowsAppSdkHostBuilder<App>();

        builder.ConfigureServices(
            (_, collection) =>
            {
                // If your main Window is named differently, change it here.
                collection.AddSingleton<MainWindow>();
            }
        );

        var app = builder.Build();

        await app.StartAsync(); // <- ... that
    }
#endif
}