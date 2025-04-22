using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class AllItemsMapDataProvider : IMapDataProvider
{
    public string[] GetMapData()
    {
        return [
            "     ",
            "     ",
            "     "
        ];
    }
}
