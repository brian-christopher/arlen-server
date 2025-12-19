using Arlen.Server.Extensions;
using Arlen.Server.Game;
using Arlen.Server.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket.WebSocket.Server;

namespace Arlen.Server;

internal static class Program
{
    private static void Configure(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<Dispatcher>();
        services.AddSingleton<World>();
        services.AddHostedService<GameLoop>();
    }

    public static async Task Main(string[] args)
    {
        var host = WebSocketHostBuilder.Create()
            .UseSession<GameSession>()
            .UseGameProtocol()
            .ConfigureServices(Configure)
            .ConfigureLogging((context, builder) => builder.AddConsole())
            .Build();

        await host.RunAsync();
    }
}