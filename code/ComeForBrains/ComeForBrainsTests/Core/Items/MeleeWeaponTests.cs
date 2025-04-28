using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.Items;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class MeleeWeaponTests : Tests
{
    MeleeWeaponBuilder builder = null!;
    MeleeWeapon weapon = null!;

    [SetUp]
    public void Setup()
    {
        builder = new MeleeWeaponBuilder()
        {
            BaseAccuracy = .65,
            BaseDamage = 10,
            Description = "D",
            EnergyConsumptionModifier = 0,
            InstantKillChance = 0.01,
            MaxEffectiveDistance = 1.2,
            MinEffectiveDistance = 0.2,
            Name = "N",
            PassabilityPenalty = 0,
            Weight = 1
        };
        weapon = new MeleeWeapon(builder);
    }

    [Test]
    public void GetAccuracy_DistanceInsideMinMax_ReturnsBaseAccuracy()
    {
        var accuracy = weapon.GetAccuracy(0.5);
        Assert.That(accuracy, Is.EqualTo(builder.BaseAccuracy));
    }

    [Test]
    public void GetAccuracy_DistanceGreaterMax_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(1.3);
        Assert.That(accuracy, Is.EqualTo(0));
    }

    [Test]
    public void GetAccuracy_DistanceLessMin_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(0.1);
        Assert.That(accuracy, Is.EqualTo(0));
    }
}