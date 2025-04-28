using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class DummyArmorJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""Jacket"": {
                    ""Name"": ""JacketName"",
                    ""Description"": ""JacketDescription"",
                    ""Weight"": 1500,
                    ""PassabilityPenalty"": 0.02,
                    ""BodyPartNames"": [
                        ""Shoulders"",
                        ""Forearms"",
                        ""Chest"",
                        ""Back"",
                        ""Stomach""
                    ],
                    ""Thikness"": 0.4,
                    ""ArmorValue"": 3,
                    ""InfectionModifier"": 0.2,
                    ""EnergyConsumptionModifier"": 0.05
                },
                ""Jeans"": {
                    ""Name"": ""JeansName"",
                    ""Description"": ""JeansDescription"",
                    ""Weight"": 1500,
                    ""PassabilityPenalty"": 0.02,
                    ""BodyPartNames"": [
                        ""Pelvis"",
                        ""Thighs"",
                        ""Shins""
                    ],
                    ""Thikness"": 0.4,
                    ""ArmorValue"": 3,
                    ""InfectionModifier"": 0.2,
                    ""EnergyConsumptionModifier"": 0.05
                }
            }";
    }
}

class DummyCampElementJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""SheetOfIron"": {
                    ""Name"": ""SheetOfIronName"",
                    ""Description"": ""SheetOfIronDescription"",
                    ""Weight"": 10000,
                    ""PassabilityPenalty"": 0.1,
                    ""MaxStrength"": 1000,
                    ""FortificationValue"": 20,
                    ""ComfortValue"": 1,
                    ""ElementTypeName"": ""External""
                },
                ""Armchair"": {
                    ""Name"": ""ArmchairName"",
                    ""Description"": ""ArmchairDescription"",
                    ""Weight"": 25000,
                    ""PassabilityPenalty"": 0.7,
                    ""MaxStrength"": 100,
                    ""FortificationValue"": 0,
                    ""ComfortValue"": 20,
                    ""ElementTypeName"": ""Internal""
                }
            }"; 
    }
}

class DummyContainerJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""WoodenBox"":{
                    ""Name"": ""WoodenBoxName"",
                    ""Description"": ""WoodenBoxDescription"",
                    ""Weight"": 2500,
                    ""PassabilityPenalty"": 0.2
                }
            }";
    }
}

class DummyInfectionKillerJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""BengalLight"": {
                    ""Name"": ""BengalLightName"",
                    ""Description"": ""BengalLightDescription"",
                    ""Weight"": 20,
                    ""PassabilityPenalty"": 0.0001,
                    ""SuccessChance"": 0.75,
                    ""EffectiveTime"": 1000,
                    ""HealthDamage"": 10
                }
            }";

    }
}

class DummyMedicineJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""Analgin"": {
                    ""Name"": ""AnalginName"",
                    ""Description"": ""AnalginDescription"",
                    ""Weight"": 3,
                    ""PassabilityPenalty"": 0.0001,
                    ""HealingPower"": 5,
                    ""Count"": 10
                }
            }";
    }
}

class DummyMeleeWeaponJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""Knife"": {
                    ""Name"": ""KnifeName"",
                    ""Description"": ""KnifeDescription"",
                    ""Weight"": 250,
                    ""PassabilityPenalty"": 0.01,
                    ""BaseDamage"": 20,
                    ""InstantKillChance"": 0.1,
                    ""BaseAccuracy"": 0.9,
                    ""EnergyConsumptionModifier"": 0.05,
                    ""MinEffectiveDistance"": 0.1,
                    ""MaxEffectiveDistance"": 1.1
                }
            }";
    }
}

class DummyProvosionJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""Bread"": {
                    ""Name"": ""BreadName"",
                    ""Description"": ""BreadDescription"",
                    ""Weight"": 300,
                    ""PassabilityPenalty"": 0.02,
                    ""SatietyPower"": 30, 
                    ""ThirstPower"": -10,
                    ""EnergyPower"": 1    
                },
                ""Water"": {
                    ""Name"": ""WaterName"",
                    ""Description"": ""WaterDescription"",
                    ""Weight"": 500,
                    ""PassabilityPenalty"": 0.02,
                    ""SatietyPower"": 0,
                    ""ThirstPower"": 25,
                    ""EnergyPower"": 5    
                }
            }";
    }
}

class DummyRangedWeaponJsonProvider : IJsonProvider
{
    public string GetJson()
    {
        return @"
            {
                ""Pistol"": {
                    ""Name"": ""PistolName"",
                    ""Description"": ""PistolDescription"",
                    ""Weight"": 900,
                    ""PassabilityPenalty"": 0.02,
                    ""BaseDamage"": 30,
                    ""InstantKillChance"": 0.1,
                    ""BaseAccuracy"": 0.9,
                    ""EnergyConsumptionModifier"": 0.05,
                    ""MinEffectiveDistance"": 1.5,
                    ""MaxEffectiveDistance"": 15.0,
                    ""NoiseDistance"": 50.0
                }
            }";
    }
}