using Arlen.Network;
using Arlen.Network.Commands;
using Arlen.Network.Events;
using Arlen.Server.Extensions;
using Arlen.Server.Game;
using Arlen.Server.Services;
using SuperSocket.Connection;
using SuperSocket.WebSocket;

namespace Arlen.Server;

public record Person(string Name, string LastName);

public sealed class GameProtocol
{
    private readonly Dispatcher _dispatcher;
    private readonly World _world;

    public GameProtocol(Dispatcher dispatcher, World world)
    {
        _dispatcher = dispatcher;
        _world = world;
    }

    public async ValueTask HandlerAsync(GameSession session, WebSocketPackage package)
    {
        var message = new Message(package.Message);
        var command = message.As<CreateCharacterCommand>();

        await session.SendAsync(new ChangeMapEvent(MapId: 2));
        await session.SendAsync(new SpawnCharacterEvent(2, "brian", 20, 20, 0, 0, 0, 0, 0));
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