using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.GameWorld;

[TestFixture]
public class SettlementTests : Tests
{
    private List<Location> locations = null!;
    Location l1 = null!;
    Location l2 = null!;
    Location l3 = null!;
    readonly IItemsBuilders itemsBuilders = new FromJsonItemBuilders(
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
        l1 = new Location(new DummyLocationBuilder("L1", new DummyMapBuilder(10, 10)), itemsBuilders);
        l2 = new Location(new DummyLocationBuilder("L2", new DummyMapBuilder(20, 20)), itemsBuilders);
        l3 = new Location(new DummyLocationBuilder("L3", new DummyMapBuilder(30, 30)), itemsBuilders);

        locations = new () {l1, l2, l3};
    }

    [Test]
    public void Creation_WithSomeLocations_AllLocationsExistsByName()
    {
        Settlement settlement = new Settlement("S", locations);

        Assert.That(settlement.GetLocation("L1"), Is.EqualTo(locations[0]));
        Assert.That(settlement.GetLocation("L2"), Is.EqualTo(locations[1]));
        Assert.That(settlement.GetLocation("L3"), Is.EqualTo(locations[2]));
    }
    [Test]
    public void Create_WithSomeLocations_AllLocationsContainsSettlementReference()
    {
        Settlement settlement = new Settlement("S", locations);

        Assert.That(locations[0].Settlement, Is.SameAs(settlement));
        Assert.That(locations[1].Settlement, Is.SameAs(settlement));
        Assert.That(locations[2].Settlement, Is.SameAs(settlement));
    }
}
