using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class AllItemsLocationJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
        {
            ""Name"": ""BeetWarehouse"",
            ""Armors"": [
                {
                    ""Name"": ""Jacket"",
                    ""Position"": [0, 0]
                }
            ],
            ""MeleeWeapons"": [
                {
                    ""Name"": ""Knife"",
                    ""Position"": [0, 1]
                }
            ],
            ""RangedWeapons"": [
                {
                    ""Name"": ""Pistol"",
                    ""Position"": [0, 2]
                }
            ],
            ""Provisions"": [
                {
                    ""Name"": ""Bread"",
                    ""Position"": [0, 3]
                }
            ],
            ""CampElements"": [
                {
                    ""Name"": ""SheetOfIron"",
                    ""Position"": [1, 0]
                }
            ],
            ""Medicines"": [
                {
                    ""Name"": ""Analgin"",
                    ""Position"": [1, 1],
                    ""Count"": 5
                }
            ],
            ""InfectionKillers"": [
                {
                    ""Name"": ""BengalLight"",
                    ""Position"": [1, 2]
                }
            ],
            ""Containers"": [
                {
                    ""Name"": ""WoodenBox"",
                    ""Content"": [
                        ""Analgin"",
                        ""SheetOfIron"",
                        ""Knife""
                    ],
                    ""Position"": [1, 3]
                }
            ]
        }
        ";
    }
}
