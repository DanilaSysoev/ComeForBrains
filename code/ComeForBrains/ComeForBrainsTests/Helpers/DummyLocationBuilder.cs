using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyLocationBuilder : ILocationBuilder
{
    public DummyLocationBuilder(
        string name,
        IMapBuilder mapBuilder
    )
    {
        this.name = name;
        this.mapBuilder = mapBuilder;
    }

    public Map BuildMap()
    {
        return new Map(mapBuilder);
    }

    public string BuildName()
    {
        return name;
    }

    public string BuildDescription()
    {
        return name + " descr";
    }

    public void PlaceItems(Map map, IItemsBuilders itemsBuilders)
    {
    }

    private readonly IMapBuilder mapBuilder;
    private readonly string name;
}
