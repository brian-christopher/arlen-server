using Arlen.Network;

namespace Arlen.Game.Entities;

public class Player : AliveEntity
{
    public GameSession Session { get; init; }

    public Player(GameSession session, World world) : base(world)
    {
        Session = session;
    }

    #region Network
    #endregion
}
