using Arlen.Network;
using Microsoft.Extensions.DependencyInjection;
using SuperSocket.Server;
using SuperSocket.Server.Abstractions.Host;
using SuperSocket.WebSocket;
using SuperSocket.WebSocket.Server;

namespace Arlen.Extensions;

public static class SuperSocketHostBuildeExtension
{
    public static ISuperSocketHostBuilder<WebSocketPackage> UseGameProtocol(this ISuperSocketHostBuilder<WebSocketPackage> builder)
    {
        return builder.ConfigureServices((context, services) =>
        {
            services.AddTransient<GameProtocol>();
            services.AddTransient<SessionHandlers>(sp =>
            {
                var protocol = sp.GetRequiredService<GameProtocol>();
                return new SessionHandlers
                {
                    Closed = (session, args) => protocol.OnSessionClosed((GameSession)session, args),
                    Connected = session => protocol.OnSessionConnected((GameSession)session)
                };
            });

            services.AddTransient<Func<WebSocketSession, WebSocketPackage, ValueTask>>(sp =>
            {
                return (session, package) => sp.GetRequiredService<GameProtocol>().HandlerAsync((GameSession)session, package);
            });
        });
    }
}
