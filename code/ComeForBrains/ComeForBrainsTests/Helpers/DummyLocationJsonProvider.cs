using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyLocationJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return
        @"{
            ""Name"": ""Mill""
        }";
    }
}
