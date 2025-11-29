namespace Arlen.Game.Entities;

public abstract class Entity
{
    private static int NextId = 0;

    public World World { get; private set; }
    public int Guid { get; private set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Position Position { get; set; }
    public int MapId { get; set; }

    protected Entity(World world)
    {
        World = world;
        Guid = ++NextId;
    }
}