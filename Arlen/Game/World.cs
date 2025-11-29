using Arlen.Game.Entities;
using Arlen.Network;
using Microsoft.Extensions.Logging;

namespace Arlen.Game;

public sealed class World
{
    private readonly ILogger<World> _logger;
    private List<Player> _players = [];

    public Player[] Players => _players.ToArray();

    public World(ILogger<World> logger)
    {
        _logger = logger;
    }

    public void Initialize()
    {

    }

    public void ConnectPlayer(GameSession session)
    {

    }

    public void DisconnectPlayer(GameSession session)
    {

    }

    public void Update(TimeSpan tickRate)
    {

    }
}
