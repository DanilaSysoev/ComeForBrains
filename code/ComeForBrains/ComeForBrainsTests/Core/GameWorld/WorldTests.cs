using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsTests.Core.GameWorld;

[TestFixture]
public class WorldTests : Tests
{
    [Test]
    public void Create_WithSomeSettlements_AllSettlementsExistsByName()
    {
        List<Settlement> settlements = new () {
            new Settlement("S1", 10, new List<Location>()),
            new Settlement("S2", 10, new List<Location>()),
            new Settlement("S3", 10, new List<Location>()),
        };

        World world = new World(settlements);

        Assert.That(world.GetSettlement("S1"), Is.EqualTo(settlements[0]));
        Assert.That(world.GetSettlement("S2"), Is.EqualTo(settlements[1]));
        Assert.That(world.GetSettlement("S3"), Is.EqualTo(settlements[2]));
    }

    [Test]
    public void Create_WithSomeSettlements_AllSettlementsContainsWorldReference()
    {
        List<Settlement> settlements = new () {
            new Settlement("S1", 10, new List<Location>()),
            new Settlement("S2", 10, new List<Location>()),
            new Settlement("S3", 10, new List<Location>()),
        };

        World world = new World(settlements);

        Assert.That(settlements[0].World, Is.SameAs(world));
        Assert.That(settlements[1].World, Is.SameAs(world));
        Assert.That(settlements[2].World, Is.SameAs(world));
    }
}
