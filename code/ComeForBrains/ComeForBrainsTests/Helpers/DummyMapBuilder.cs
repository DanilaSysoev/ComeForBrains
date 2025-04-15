using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyMapBuilder : IMapBuilder
{
    public int Width { get; set; }
    public int Height { get; set; }

    public DummyMapBuilder(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int GetHeight()
    {
        return Height;
    }

    public int GetWidth()
    {
        return Width;
    }

    public Tile GetTile(int line, int column)
    {
        return new Tile($"T{line}", $"D{column}");
    }

    public void Build()
    {
    }
}
