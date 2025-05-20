using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class LoadingItemsTests : Tests
{
    private JsonFilesLocationBuilder locationBuilder = null!;

    private readonly IItemsBuilders itemsBuilders = new FromJsonItemBuilders(
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


    [SetUp]
    public void Setup()
    {
        locationBuilder = new JsonFilesLocationBuilder(
            new TextFileMapBuilder(
                new AllItemsMapDataProvider(),
                new DummyTileDescriptorJsonProvider()
            ),
            new AllItemsLocationJsonProvider().LocationProvider,
            new AllItemsLocationJsonProvider().ItemsProvider
        );
    }

    [Test]
    public void Build_CallMethod_BuildWithoutErrors()
    {
        Assert.DoesNotThrow(() => new Location(locationBuilder, itemsBuilders));
    }

    [Test]
    public void Build_CallMethod_ArmorsIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[0, 0].Items.Count(item => item is Armor),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_ArmorsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 0].Items
                               .Where(item => item is Armor)
                               .ToList()[0] as Armor)!;
        Assert.That(item.Name, Is.EqualTo("JacketName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.02));
        Assert.That(item.Weight, Is.EqualTo(1500));
        Assert.That(item.Thikness, Is.EqualTo(0.4));
        Assert.That(item.ArmorValue, Is.EqualTo(3));
        Assert.That(item.InfectionModifier, Is.EqualTo(0.2));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(0.05));
    }
    [Test]
    public void Build_CallMethod_CorrectedArmorsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 0].Items.Where(item => item is Armor)
                                     .ToList()[1] as Armor)!;
        Assert.That(item.Name, Is.EqualTo("JacketName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.02));
        Assert.That(item.Weight, Is.EqualTo(1501));
        Assert.That(item.Thikness, Is.EqualTo(1.4));
        Assert.That(item.ArmorValue, Is.EqualTo(4));
        Assert.That(item.InfectionModifier, Is.EqualTo(1.2));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(1.05));
    }

    [Test]
    public void Build_CallMethod_MeleeWeaponsIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[0, 1].Items.Count(item => item is MeleeWeapon),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_MeleeWeaponsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 1].Items
                               .Where(item => item is MeleeWeapon)
                               .ToList()[0] as MeleeWeapon)!;
        Assert.That(item.Name, Is.EqualTo("KnifeName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.01));
        Assert.That(item.Weight, Is.EqualTo(250));
        Assert.That(item.BaseDamage, Is.EqualTo(20));
        Assert.That(item.InstantKillChance, Is.EqualTo(0.1));
        Assert.That(item.BaseAccuracy, Is.EqualTo(0.9));
        Assert.That(item.MaxEffectiveDistance, Is.EqualTo(1.1));
        Assert.That(item.MinEffectiveDistance, Is.EqualTo(0.1));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(0.05));
    }
    [Test]
    public void Build_CallMethod_CorrectedMeleeWeaponsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 1].Items
                               .Where(item => item is MeleeWeapon)
                               .ToList()[1] as MeleeWeapon)!;
        Assert.That(item.Name, Is.EqualTo("KnifeName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.01));
        Assert.That(item.Weight, Is.EqualTo(251));
        Assert.That(item.BaseDamage, Is.EqualTo(21));
        Assert.That(item.InstantKillChance, Is.EqualTo(1.1));
        Assert.That(item.BaseAccuracy, Is.EqualTo(1.9));
        Assert.That(item.MaxEffectiveDistance, Is.EqualTo(2.1));
        Assert.That(item.MinEffectiveDistance, Is.EqualTo(1.1));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(1.05));
    }

    [Test]
    public void Build_CallMethod_RangedWeaponsIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[0, 2].Items.Count(item => item is RangedWeapon),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_RangedWeaponsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 2].Items
                               .Where(item => item is RangedWeapon)
                               .ToList()[0] as RangedWeapon)!;
        Assert.That(item.Name, Is.EqualTo("PistolName"));
        Assert.That(item.Weight, Is.EqualTo(900));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.02));
        Assert.That(item.BaseDamage, Is.EqualTo(30));
        Assert.That(item.InstantKillChance, Is.EqualTo(0.1));
        Assert.That(item.BaseAccuracy, Is.EqualTo(0.9));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(0.05));
        Assert.That(item.MaxEffectiveDistance, Is.EqualTo(15.0));
        Assert.That(item.MinEffectiveDistance, Is.EqualTo(1.5));
        Assert.That(item.NoiseDistance, Is.EqualTo(50.0));
    }
    [Test]
    public void Build_CallMethod_CorrectedRangedWeaponsPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 2].Items
                               .Where(item => item is RangedWeapon)
                               .ToList()[1] as RangedWeapon)!;
        Assert.That(item.Name, Is.EqualTo("PistolName"));
        Assert.That(item.Weight, Is.EqualTo(901));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.02));
        Assert.That(item.BaseDamage, Is.EqualTo(31));
        Assert.That(item.InstantKillChance, Is.EqualTo(1.1));
        Assert.That(item.BaseAccuracy, Is.EqualTo(1.9));
        Assert.That(item.EnergyConsumptionModifier, Is.EqualTo(1.05));
        Assert.That(item.MaxEffectiveDistance, Is.EqualTo(16.0));
        Assert.That(item.MinEffectiveDistance, Is.EqualTo(2.5));
        Assert.That(item.NoiseDistance, Is.EqualTo(51.0));
    }

    [Test]
    public void Build_CallMethod_ProvisionIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[0, 3].Items.Count(item => item is Provision),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_ProvisionPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 3].Items
                               .Where(item => item is Provision)
                               .ToList()[0] as Provision)!;
        Assert.That(item.Name, Is.EqualTo("BreadName"));
        Assert.That(item.Weight, Is.EqualTo(300));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.02));
        Assert.That(item.SatietyPower, Is.EqualTo(30));
        Assert.That(item.ThirstPower, Is.EqualTo(-10));
        Assert.That(item.EnergyPower, Is.EqualTo(1));
    }
    [Test]
    public void Build_CallMethod_CorrectedProvisionPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[0, 3].Items
                               .Where(item => item is Provision)
                               .ToList()[1] as Provision)!;
        Assert.That(item.Name, Is.EqualTo("BreadName"));
        Assert.That(item.Weight, Is.EqualTo(301));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.02));
        Assert.That(item.SatietyPower, Is.EqualTo(31));
        Assert.That(item.ThirstPower, Is.EqualTo(-11));
        Assert.That(item.EnergyPower, Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_CampElementIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[1, 0].Items.Count(item => item is CampElement),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_CampElementPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 0].Items
                               .Where(item => item is CampElement)
                               .ToList()[0] as CampElement)!;
        Assert.That(item.Name, Is.EqualTo("SheetOfIronName"));
        Assert.That(item.Weight, Is.EqualTo(10000));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.1));
        Assert.That(item.MaxStrength, Is.EqualTo(1000));
        Assert.That(item.Fortification, Is.EqualTo(20));
        Assert.That(item.Comfort, Is.EqualTo(1));
        Assert.That(item.ElementType, Is.EqualTo(CampElementType.External));
    }
    [Test]
    public void Build_CallMethod_CorrectedCampElementPropertiesSetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 0].Items
                               .Where(item => item is CampElement)
                               .ToList()[1] as CampElement)!;
        Assert.That(item.Name, Is.EqualTo("SheetOfIronName"));
        Assert.That(item.Weight, Is.EqualTo(10001));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.1));
        Assert.That(item.MaxStrength, Is.EqualTo(1001));
        Assert.That(item.Fortification, Is.EqualTo(21));
        Assert.That(item.Comfort, Is.EqualTo(2));
        Assert.That(item.ElementType, Is.EqualTo(CampElementType.External));
    }

    [Test]
    public void Build_CallMethod_MedicineIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[1, 1].Items.Count(item => item is Medicine),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_MedicinePropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 1].Items
                               .Where(item => item is Medicine)
                               .ToList()[0] as Medicine)!;
        Assert.That(item.Name, Is.EqualTo("AnalginName"));
        Assert.That(item.Weight, Is.EqualTo(3));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.0001));
        Assert.That(item.HealingPower, Is.EqualTo(5));
        Assert.That(item.Count, Is.EqualTo(5));
    }
    [Test]
    public void Build_CallMethod_CorrectedMedicinePropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 1].Items
                               .Where(item => item is Medicine)
                               .ToList()[1] as Medicine)!;
        Assert.That(item.Name, Is.EqualTo("AnalginName"));
        Assert.That(item.Weight, Is.EqualTo(4));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.0001));
        Assert.That(item.HealingPower, Is.EqualTo(6));
        Assert.That(item.Count, Is.EqualTo(10));
    }

    [Test]
    public void Build_CallMethod_InfectionKillerIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[1, 2].Items.Count(item => item is InfectionKiller),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_InfectionKillerPropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 2].Items
                               .Where(item => item is InfectionKiller)
                               .ToList()[0] as InfectionKiller)!;
        Assert.That(item.Name, Is.EqualTo("BengalLightName"));
        Assert.That(item.Weight, Is.EqualTo(20));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.0001));
        Assert.That(item.SuccessChance, Is.EqualTo(0.75));
        Assert.That(item.EffectiveTime, Is.EqualTo(1000));
        Assert.That(item.HealthDamage, Is.EqualTo(10));
    }
    [Test]
    public void Build_CallMethod_CorrectedInfectionKillerPropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 2].Items
                               .Where(item => item is InfectionKiller)
                               .ToList()[1] as InfectionKiller)!;
        Assert.That(item.Name, Is.EqualTo("BengalLightName"));
        Assert.That(item.Weight, Is.EqualTo(21));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.0001));
        Assert.That(item.SuccessChance, Is.EqualTo(1.75));
        Assert.That(item.EffectiveTime, Is.EqualTo(1001));
        Assert.That(item.HealthDamage, Is.EqualTo(11));
    }

    [Test]
    public void Build_CallMethod_ContainerIsLoaded()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        Assert.That(location.Map[1, 3].Items.Count(item => item is Container),
                    Is.EqualTo(2));
    }

    [Test]
    public void Build_CallMethod_ContainerPropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 3].Items
                               .Where(item => item is Container)
                               .ToList()[0] as Container)!;
        Assert.That(item.Name, Is.EqualTo("WoodenBoxName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(0.2));
        Assert.That(item.Count(content => content.Name == "AnalginName"), Is.EqualTo(1));
        Assert.That(item.Count(content => content.Name == "SheetOfIronName"), Is.EqualTo(1));
        Assert.That(item.Count(content => content.Name == "KnifeName"), Is.EqualTo(1));
    }
    [Test]
    public void Build_CallMethod_CorrectedContainerPropertySetCorrectly()
    {
        var location = new Location(locationBuilder, itemsBuilders);
        var item =
            (location.Map[1, 3].Items
                               .Where(item => item is Container)
                               .ToList()[1] as Container)!;
        Assert.That(item.Name, Is.EqualTo("WoodenBoxName"));
        Assert.That(item.PassabilityPenalty, Is.EqualTo(1.2));
        Assert.That(item.Weight, Is.EqualTo(2504));
        Assert.That(item.Count(content => content.Name == "AnalginName"), Is.EqualTo(1));
    }
    
}
