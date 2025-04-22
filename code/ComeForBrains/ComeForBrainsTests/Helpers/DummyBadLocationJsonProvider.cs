using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class DummyBadLocationJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return
        @"{
            ""Name"": ""Mill"",
            ""RangedWeapon"": [
                {
                    ""Name"": ""Pistol"",
                    ""Position"": [0, 0]
                }
            ],
            ""Armor"": [
                {
                    ""Name"": ""Jacket"",
                    ""Position"": [1, 0]
                }
            ],
            ""Containers"": [
                {
                    ""Name"": ""WoodenBox"",
                    ""Content"": [
                        ""Analgin""
                    ],
                    ""Position"": [10, 10]
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
        }";
    }
}
