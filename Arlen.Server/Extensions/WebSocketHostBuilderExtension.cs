using Arlen.Network;
using Microsoft.Extensions.DependencyInjection;
using SuperSocket.Server;
using SuperSocket.Server.Abstractions.Host;
using SuperSocket.WebSocket;
using SuperSocket.WebSocket.Server;
using System.Text.Json;

namespace Arlen.Server.Extensions;

public static class WebSocketHostBuilderExtension
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static ISuperSocketHostBuilder<WebSocketPackage> UseGameProtocol(
        this ISuperSocketHostBuilder<WebSocketPackage> builder)
    {
        return builder.ConfigureServices((context, services) =>
        {
            services.AddTransient<GameProtocol>();
            
            services.AddTransient<SessionHandlers>(sp =>
            {
                var handlers = sp.GetRequiredService<GameProtocol>();
                return new SessionHandlers
                {
                    Connected = session => handlers.OnConnectedAsync((GameSession)session),
                    Closed = (session, args) => handlers.OnDisconnectedAsync((GameSession)session, args)
                };
            });
            
            services.AddTransient<Func<WebSocketSession, WebSocketPackage, ValueTask>>(sp =>
            {
                return async (session, package) => await sp.GetRequiredService<GameProtocol>().HandlerAsync((GameSession)session, package);
            });
        });
    }

    public static async ValueTask SendAsync<T>(this GameSession session, T package)
        where T : IPackage
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(package);

        var message = JsonSerializer.Serialize(package, Options)!;
        await session.SendAsync(message);
    }
}