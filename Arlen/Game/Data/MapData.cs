namespace Arlen.Game.Data;

public class MapData
{
    public string Name { get; set; } = string.Empty;
    public int Width { get; set; }
    public int Height { get; set; }
    public int[] Tiles { get; set; } = [];
    public int MinLevel { get; set; }
    public bool IsPremium { get; set; }
    public string MapType { get; set; } = string.Empty;
    public string TerrainType { get; set; } = string.Empty;
}