namespace ComeForBrains.Core.Building;

public interface IMapBuilder
{
    public int GetWidth();
    public int GetHeight();

    public Tile GetTile(int line, int column);
}
