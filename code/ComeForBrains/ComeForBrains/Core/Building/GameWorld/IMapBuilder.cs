using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface IMapBuilder
{
    public int GetWidth();
    public int GetHeight();

    public Tile GetTile(int line, int column);
}
