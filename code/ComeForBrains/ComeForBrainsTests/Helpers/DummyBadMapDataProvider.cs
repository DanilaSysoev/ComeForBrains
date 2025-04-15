using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyBadMapDataProvider : IMapDataProvider
{
    public string[] GetMapData()
    {
        return new string[]
        {
            ".#.",
            "# #",
            ".#*"
        };
    }
}
