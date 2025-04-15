using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface IMapBuilder
{
    void Build();

    int GetWidth();
    int GetHeight();

    Tile GetTile(int line, int column);
}
