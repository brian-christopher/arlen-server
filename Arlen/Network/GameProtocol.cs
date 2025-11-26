using SuperSocket.WebSocket;  

namespace Arlen.Network;

public class GameProtocol
{
    public ValueTask HandlerAsync(GameSession session, WebSocketPackage package)
    {
        ParsePacket(session, package);
        return ValueTask.CompletedTask;
    }

    private void ParsePacket(GameSession session, WebSocketPackage package)
    { 
    }

    public ValueTask OnSessionClosed(GameSession session, object? args)
    {
        // Handle session opened logic here
        return ValueTask.CompletedTask;
    }

    public ValueTask OnSessionConnected(GameSession session)
    {
        return ValueTask.CompletedTask;
    }
}
