namespace ComeForBrains.Core.MapBuilding;

public interface IMapBuilder
{
    public int GetWidth();
    public int GetHeight();

    public Tile GetTile(int line, int column);
}
