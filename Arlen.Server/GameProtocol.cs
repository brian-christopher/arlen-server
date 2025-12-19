using Arlen.Server.Game;
using Arlen.Server.Services;
using SuperSocket.Connection;
using SuperSocket.WebSocket;

namespace Arlen.Server;

public sealed class GameProtocol
{
    private readonly Dispatcher _dispatcher;
    private readonly World _world;

    public GameProtocol(Dispatcher dispatcher, World world)
    {
        _dispatcher = dispatcher;
        _world = world;
    }
    
    public ValueTask HandlerAsync(GameSession session, WebSocketPackage package)
    {
        return ValueTask.CompletedTask;
    }
    
    public ValueTask OnConnectedAsync(GameSession session)
    {
        return ValueTask.CompletedTask;
    }
    
    public ValueTask OnDisconnectedAsync(GameSession session, CloseEventArgs args)
    {
        return ValueTask.CompletedTask;
    }
}