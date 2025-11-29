using Arlen.Extensions;
using Arlen.Game;
using Arlen.Network.Messages.Events;
using SuperSocket.WebSocket;

namespace Arlen.Network;

public class GameProtocol
{
    public async ValueTask HandlerAsync(GameSession session, WebSocketPackage package)
    {
        await ParsePacketAsync(session, package);
    }

    private async Task ParsePacketAsync(GameSession session, WebSocketPackage package)
    {
        await session.SendAsync(new CharacterSpawnedEvent(1, "brian", 30, 30));
    }

    public ValueTask OnSessionClosed(GameSession session, object? args)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask OnSessionConnected(GameSession session)
    {
        return ValueTask.CompletedTask;
    }
}
