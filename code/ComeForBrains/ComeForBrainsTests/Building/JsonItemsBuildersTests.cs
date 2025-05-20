using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.Characters;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class JsonItemsBuildersTests
{
    private IItemsBuilders builders = null!;

    [SetUp]
    public void Setup()
    {
        builders = new FromJsonItemBuilders(
            new DummyArmorJsonProvider(),
            new DummyCampElementJsonProvider(),
            new DummyContainerJsonProvider(),
            new DummyInfectionKillerJsonProvider(),
            new DummyMedicineJsonProvider(),
            new DummyMeleeWeaponJsonProvider(),
            new DummyProvosionJsonProvider(),
            new DummyRangedWeaponJsonProvider(),
            new DummyFuelJsonProvider()
        );  
    }

    [Test]
    public void Creation_CreateFromJson_CreatedWithoutError()
    {
        Assert.DoesNotThrow(
            () => new FromJsonItemBuilders(
                new DummyArmorJsonProvider(),
                new DummyCampElementJsonProvider(),
                new DummyContainerJsonProvider(),
                new DummyInfectionKillerJsonProvider(),
                new DummyMedicineJsonProvider(),
                new DummyMeleeWeaponJsonProvider(),
                new DummyProvosionJsonProvider(),
                new DummyRangedWeaponJsonProvider(),
                new DummyFuelJsonProvider()
            )
        );
    }

    [Test]
    public void GetBuilder_GetByName_BuiildeExists()
    {
        Assert.DoesNotThrow(() => builders.GetArmorBuilder("Jacket"));
        Assert.DoesNotThrow(() => builders.GetArmorBuilder("Jeans"));

        Assert.DoesNotThrow(() => builders.GetCampElementBuilder("SheetOfIron"));
        Assert.DoesNotThrow(() => builders.GetCampElementBuilder("Armchair"));

        Assert.DoesNotThrow(() => builders.GetContainerBuilder("WoodenBox"));

        Assert.DoesNotThrow(() => builders.GetInfectionKillerBuilder("BengalLight"));

        Assert.DoesNotThrow(() => builders.GetMedicineBuilder("Analgin"));

        Assert.DoesNotThrow(() => builders.GetMeleeWeaponBuilder("Knife"));

        Assert.DoesNotThrow(() => builders.GetProvisionBuilder("Bread"));
        Assert.DoesNotThrow(() => builders.GetProvisionBuilder("Water"));

        Assert.DoesNotThrow(() => builders.GetRangedWeaponBuilder("Pistol"));
    }

    [Test]
    public void ArmorBuilders_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var jacket = builders.GetArmorBuilder("Jacket");

        Assert.That(jacket.Name, Is.EqualTo("JacketName"));
        Assert.That(jacket.Description, Is.EqualTo("JacketDescription"));
        Assert.That(jacket.Weight, Is.EqualTo(1500));
        Assert.That(jacket.PassabilityPenalty, Is.EqualTo(0.02).Within(0.0000001));
        Assert.That(jacket.EnergyConsumptionModifier, Is.EqualTo(0.05).Within(0.0000001));
        Assert.That(jacket.ArmorValue, Is.EqualTo(3).Within(0.0000001));
        Assert.That(jacket.BodyParts, Is.EquivalentTo(new[] { BodyPart.Shoulders, BodyPart.Forearms, BodyPart.Chest, BodyPart.Back, BodyPart.Stomach }));
        Assert.That(jacket.InfectionModifier, Is.EqualTo(0.2).Within(0.0000001));
        Assert.That(jacket.Thikness, Is.EqualTo(0.4).Within(0.0000001));
    }

    [Test]
    public void CampElementBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var sheetOfIron = builders.GetCampElementBuilder("SheetOfIron");

        Assert.That(sheetOfIron.Name, Is.EqualTo("SheetOfIronName"));
        Assert.That(sheetOfIron.Description, Is.EqualTo("SheetOfIronDescription"));
        Assert.That(sheetOfIron.Weight, Is.EqualTo(10000));
        Assert.That(sheetOfIron.PassabilityPenalty, Is.EqualTo(0.1).Within(0.0000001));
        Assert.That(sheetOfIron.MaxStrength, Is.EqualTo(1000).Within(0.00001));
        Assert.That(sheetOfIron.FortificationValue, Is.EqualTo(20).Within(0.00001));
        Assert.That(sheetOfIron.ComfortValue, Is.EqualTo(1).Within(0.0000001));
    }

    [Test]
    public void ContainerBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var woodenBox = builders.GetContainerBuilder("WoodenBox");

        Assert.That(woodenBox.Name, Is.EqualTo("WoodenBoxName"));
        Assert.That(woodenBox.Description, Is.EqualTo("WoodenBoxDescription"));
        Assert.That(woodenBox.Weight, Is.EqualTo(2500));
        Assert.That(woodenBox.PassabilityPenalty, Is.EqualTo(0.2).Within(0.0000001));
    }

    [Test]
    public void InfectionKillerBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var bengalLight = builders.GetInfectionKillerBuilder("BengalLight");

        Assert.That(bengalLight.Name, Is.EqualTo("BengalLightName"));
        Assert.That(bengalLight.Description, Is.EqualTo("BengalLightDescription"));
        Assert.That(bengalLight.Weight, Is.EqualTo(20));
        Assert.That(bengalLight.PassabilityPenalty, Is.EqualTo(0.0001).Within(0.0000001));
        Assert.That(bengalLight.SuccessChance, Is.EqualTo(0.75).Within(0.0000001));
        Assert.That(bengalLight.EffectiveTime, Is.EqualTo(1000).Within(0.00001));
        Assert.That(bengalLight.HealthDamage, Is.EqualTo(10).Within(0.000001));
    }

    [Test]
    public void MedicineBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var analgin = builders.GetMedicineBuilder("Analgin");

        Assert.That(analgin.Name, Is.EqualTo("AnalginName"));
        Assert.That(analgin.Description, Is.EqualTo("AnalginDescription"));
        Assert.That(analgin.Weight, Is.EqualTo(3));
        Assert.That(analgin.PassabilityPenalty, Is.EqualTo(0.0001).Within(0.0000001));
        Assert.That(analgin.HealingPower, Is.EqualTo(5).Within(0.000001));
        Assert.That(analgin.Count, Is.EqualTo(10));
    }

    [Test]
    public void MeleeWeaponBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var knife = builders.GetMeleeWeaponBuilder("Knife");

        Assert.That(knife.Name, Is.EqualTo("KnifeName"));
        Assert.That(knife.Description, Is.EqualTo("KnifeDescription"));
        Assert.That(knife.Weight, Is.EqualTo(250));
        Assert.That(knife.PassabilityPenalty, Is.EqualTo(0.01).Within(0.0000001));
        Assert.That(knife.BaseDamage, Is.EqualTo(20).Within(0.00001));
        Assert.That(knife.BaseAccuracy, Is.EqualTo(0.9).Within(0.000001));
        Assert.That(knife.EnergyConsumptionModifier, Is.EqualTo(0.05).Within(0.0000001));
        Assert.That(knife.MinEffectiveDistance, Is.EqualTo(0.1).Within(0.000001));
        Assert.That(knife.MaxEffectiveDistance, Is.EqualTo(1.1).Within(0.000001));
        Assert.That(knife.InstantKillChance, Is.EqualTo(0.1).Within(0.0000001));
    }

    [Test]
    public void ProvisionBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var bread = builders.GetProvisionBuilder("Bread");

        Assert.That(bread.Name, Is.EqualTo("BreadName"));
        Assert.That(bread.Description, Is.EqualTo("BreadDescription"));
        Assert.That(bread.Weight, Is.EqualTo(300));
        Assert.That(bread.PassabilityPenalty, Is.EqualTo(0.02).Within(0.0000001));
        Assert.That(bread.SatietyPower, Is.EqualTo(30).Within(0.00001));
        Assert.That(bread.ThirstPower, Is.EqualTo(-10).Within(0.00001));
        Assert.That(bread.EnergyPower, Is.EqualTo(1).Within(0.00001));
    }

    [Test]
    public void RangedWeaponBuilder_ConfiguredBuilders_AllProoertiesSetCorrectly()
    {
        var pistol = builders.GetRangedWeaponBuilder("Pistol");

        Assert.That(pistol.Name, Is.EqualTo("PistolName"));
        Assert.That(pistol.Description, Is.EqualTo("PistolDescription"));
        Assert.That(pistol.Weight, Is.EqualTo(900));
        Assert.That(pistol.PassabilityPenalty, Is.EqualTo(0.02).Within(0.0000001));
        Assert.That(pistol.EnergyConsumptionModifier, Is.EqualTo(0.05).Within(0.0000001));
        Assert.That(pistol.BaseDamage, Is.EqualTo(30).Within(0.00001));
        Assert.That(pistol.BaseAccuracy, Is.EqualTo(0.9).Within(0.000001));
        Assert.That(pistol.MinEffectiveDistance, Is.EqualTo(1.5).Within(0.000001));
        Assert.That(pistol.MaxEffectiveDistance, Is.EqualTo(15.0).Within(0.000001));
        Assert.That(pistol.InstantKillChance, Is.EqualTo(0.1).Within(0.0000001));
        Assert.That(pistol.NoiseDistance, Is.EqualTo(50).Within(0.00001));        
    }
}
