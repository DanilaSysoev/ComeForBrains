using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class DummyTileDescriptorJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return 
        @"[
            {
                ""symbol"": ""#"",
                ""name"": ""BrickWall"",
                ""description"": ""BrickWallDescription"",
                ""passability"": 0
            },
            {
                ""symbol"": "" "",
                ""name"": ""Ground"",
                ""description"": ""GroundDescription"",
                ""passability"": 1.0
            },
            {
                ""symbol"": ""."",
                ""name"": ""Grass"",
                ""description"": ""GrassDescription"",
                ""passability"": 0.9
            }
        ]";
    }
}
