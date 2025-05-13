using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class AllItemsLocationJsonProvider
{
    public IJsonProvider LocationProvider { get; } = new FromTextJsonProvider(
        @"
            {
                ""Name"": ""BeetWarehouse""
            }
        "
    );

    public IJsonProvider ItemsProvider { get; } = new FromTextJsonProvider(
        @"
            {
                ""Name"": ""BeetWarehouse"",
                ""Armors"": [
                    {
                        ""Name"": ""Jacket"",
                        ""Position"": [0, 0]
                    },
                    {
                        ""Name"": ""Jacket"",
                        ""Position"": [0, 0],
                        ""Weight"": 1501,
                        ""PassabilityPenalty"": 1.02,
                        ""Thikness"": 1.4,
                        ""ArmorValue"": 4,
                        ""InfectionModifier"": 1.2,
                        ""EnergyConsumptionModifier"": 1.05
                    }
                ],
                ""MeleeWeapons"": [
                    {
                        ""Name"": ""Knife"",
                        ""Position"": [0, 1]
                    },
                    {
                        ""Name"": ""Knife"",
                        ""Position"": [0, 1],
                        ""Weight"": 251,
                        ""PassabilityPenalty"": 1.01,
                        ""BaseDamage"": 21,
                        ""InstantKillChance"": 1.1,
                        ""BaseAccuracy"": 1.9,
                        ""EnergyConsumptionModifier"": 1.05,
                        ""MinEffectiveDistance"": 1.1,
                        ""MaxEffectiveDistance"": 2.1
                    }
                ],
                ""RangedWeapons"": [
                    {
                        ""Name"": ""Pistol"",
                        ""Position"": [0, 2]
                    },
                    {
                        ""Name"": ""Pistol"",
                        ""Position"": [0, 2],
                        ""Weight"": 901,
                        ""PassabilityPenalty"": 1.02,
                        ""BaseDamage"": 31,
                        ""InstantKillChance"": 1.1,
                        ""BaseAccuracy"": 1.9,
                        ""EnergyConsumptionModifier"": 1.05,
                        ""MinEffectiveDistance"": 2.5,
                        ""MaxEffectiveDistance"": 16.0,
                        ""NoiseDistance"": 51.0
                    }
                ],
                ""Provisions"": [
                    {
                        ""Name"": ""Bread"",
                        ""Position"": [0, 3]
                    },
                    {
                        ""Name"": ""Bread"",
                        ""Position"": [0, 3],
                        ""Weight"": 301,
                        ""PassabilityPenalty"": 1.02,
                        ""SatietyPower"": 31, 
                        ""ThirstPower"": -11,
                        ""EnergyPower"": 2 
                    }
                ],
                ""CampElements"": [
                    {
                        ""Name"": ""SheetOfIron"",
                        ""Position"": [1, 0]
                    },
                    {
                        ""Name"": ""SheetOfIron"",
                        ""Position"": [1, 0],
                        ""Weight"": 10001,
                        ""PassabilityPenalty"": 1.1,
                        ""MaxStrength"": 1001,
                        ""FortificationValue"": 21,
                        ""ComfortValue"": 2
                    }
                ],
                ""Medicines"": [
                    {
                        ""Name"": ""Analgin"",
                        ""Position"": [1, 1],
                        ""Count"": 5
                    },
                    {
                        ""Name"": ""Analgin"",
                        ""Position"": [1, 1],
                        ""Weight"": 4,
                        ""PassabilityPenalty"": 1.0001,
                        ""HealingPower"": 6
                    }
                ],
                ""InfectionKillers"": [
                    {
                        ""Name"": ""BengalLight"",
                        ""Position"": [1, 2]
                    },
                    {
                        ""Name"": ""BengalLight"",
                        ""Position"": [1, 2],
                        ""Weight"": 21,
                        ""PassabilityPenalty"": 1.0001,
                        ""SuccessChance"": 1.75,
                        ""EffectiveTime"": 1001,
                        ""HealthDamage"": 11
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
                    },
                    {
                        ""Name"": ""WoodenBox"",
                        ""Content"": [
                            ""Analgin""
                        ],
                        ""Position"": [1, 3],
                        ""Weight"": 2501,
                        ""PassabilityPenalty"": 1.2
                    }
                ]
            }
        "
    );
}
