namespace Arlen.Game.Entities;

[Flags]
public enum TileState
{
    None,
    Blocked
}

public class Tile
{
    public Entity? Entity { get; set; }
    public TileState State { get; set; }
}

public sealed class Map
{
    private Tile[] _tiles = [];

    public string Name { get; set; } = string.Empty;
    public int Id { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public int MinLevel { get; set; }
    public bool IsPremium { get; set; }

    public string MapType { get; set; } = string.Empty;
    public string TerrainType { get; set; } = string.Empty;

    public Map(int id, int width, int height)
    {
        Width = width;
        Height = height;
        Id = id;

        _tiles = new Tile[width * height];
    }

    public Tile GetTile(int x, int y)
    {
        return _tiles[x + y * Width];
    }

    public bool InMapBounds(int x, int y)
        => x >= 0 && y >= 0 && x < Width && y < Height;
}