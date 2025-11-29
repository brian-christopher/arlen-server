using SuperSocket.WebSocket.Server;

namespace Arlen.Network;

public class GameSession : WebSocketSession
{
    public int? PlayerId { get; set; }
}