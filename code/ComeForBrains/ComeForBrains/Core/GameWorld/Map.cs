using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrains.Core.GameWorld;

public class Map
{
    public int Width { get; init; }
    public int Height { get; init; }

    public Map(IMapBuilder builder)
    {
        builder.Build();

        Width = builder.GetWidth();
        Height = builder.GetHeight();

        tiles = new Tile[Width, Height];
        for (int line = 0; line < Height; line++)
            for (int column = 0; column < Width; column++)
                tiles[line, column] = builder.GetTile(line, column);
    }

    public Tile this[int line, int column]
    {
        get => tiles[line, column];
    }
    public Tile this[Position position]
        => tiles[position.Line, position.Column];

    public override string ToString()
    {
        return $"Map: {Width}x{Height}";
    }


    private readonly Tile[,] tiles;
}
