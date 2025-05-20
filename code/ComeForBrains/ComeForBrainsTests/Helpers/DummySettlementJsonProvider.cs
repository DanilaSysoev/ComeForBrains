using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummySettlementJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
        {
            ""Name"": ""Borshevka"",
            ""Locations"": [
                ""Mill"",
                ""Village""
            ],
            ""DistanceToCamp"": 10
        }";
    }
}

public class DummyVillageProvider : IJsonProvider, IMapDataProvider
{
    public string GetJson()
    {        
        return
        @"{
            ""Name"": ""Village""
        }";
    }

    public string[] GetMapData()
    {
        return [
            "   ",
            "   "
        ];
    }
}