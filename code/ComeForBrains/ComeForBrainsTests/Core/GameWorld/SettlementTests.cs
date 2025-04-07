using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsTests.Core.GameWorld;

[TestFixture]
public class SettlementTests : Tests
{
    [Test]
    public void Creation_WithSomeLocations_AllLocationsExistsByName()
    {
        List<Location> locations = new () {
            new Location("L1"),
            new Location("L2"),
            new Location("L3"),
        };

        Settlement settlement = new Settlement("S", locations);

        Assert.That(settlement.GetLocation("L1"), Is.EqualTo(locations[0]));
        Assert.That(settlement.GetLocation("L2"), Is.EqualTo(locations[1]));
        Assert.That(settlement.GetLocation("L3"), Is.EqualTo(locations[2]));
    }
    [Test]
    public void Create_WithSomeLocations_AllLocationsContainsSettlementReference()
    {
        List<Location> locations = new () {
            new Location("L1"),
            new Location("L2"),
            new Location("L3"),
        };

        Settlement settlement = new Settlement("S", locations);

        Assert.That(locations[0].Settlement, Is.SameAs(settlement));
        Assert.That(locations[1].Settlement, Is.SameAs(settlement));
        Assert.That(locations[2].Settlement, Is.SameAs(settlement));
    }
}
