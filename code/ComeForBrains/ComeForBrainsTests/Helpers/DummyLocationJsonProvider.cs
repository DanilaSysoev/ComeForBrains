using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class DummyLocationJsonProvider
{
    public IJsonProvider LocationProvider { get; } = new FromTextJsonProvider(
        @"{
            ""Name"": ""Mill"",
            ""Description"": ""Here is a small mill""
        }"
    );
    public IJsonProvider ItemsProvider { get; } = new FromTextJsonProvider(
        @"{
            ""Armors"": [
                {
                    ""Name"": ""Jacket"",
                    ""Position"": [2, 0]
                }
            ],
            ""RangedWeapons"": [            
                {
                    ""Name"": ""Pistol"",
                    ""Position"": [0, 0]
                }
            ],
            ""Containers"": [
                {
                    ""Name"": ""WoodenBox"",
                    ""Content"": [
                        ""Analgin""
                    ],
                    ""Position"": [1, 1]
                },
                {
                    ""Name"": ""WoodenBox"",
                    ""Content"": [
                        ""SheetOfIron"",
                        ""SheetOfIron""
                    ],
                    ""Position"": [2, 1]
                }
            ]            
        }"
    );
}
