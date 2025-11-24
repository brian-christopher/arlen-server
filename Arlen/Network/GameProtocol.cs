using Arlen.Network.Events;
using SuperSocket.WebSocket; 
using Arlen.Extensions;

namespace Arlen.Network;

public class GameProtocol
{
    public async ValueTask HandlerAsync(GameSession session, WebSocketPackage package)
    {
        ParsePacket(session, package);
    }

    private void ParsePacket(GameSession session, WebSocketPackage package)
    {
        var command = new ParsedCommand(package.Message);

        switch(command.Opcode)
        {

        }
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
