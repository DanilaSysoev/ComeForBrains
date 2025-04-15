using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyMapDataProvider : IMapDataProvider
{
    public string[] GetMapData()
    {
        return new string[]
        {
            ".#.",
            "# #",
            "# #",
            ".#."
        };
    }
}
