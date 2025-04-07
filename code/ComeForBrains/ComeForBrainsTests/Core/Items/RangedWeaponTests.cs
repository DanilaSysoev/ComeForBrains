using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.Items;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class RangedWeaponTests : Tests
{
    RangedWeaponBuilder builder = null!;
    RangedWeapon weapon = null!;

    [SetUp]
    public void Setup()
    {
        builder = new RangedWeaponBuilder()
        {
            BaseAccuracy = .65,
            BaseDamage = 10,
            Description = "D",
            EnergyConsumptionModifier = 0,
            InstantKillChance = 0.01,
            MaxEffectiveDistance = 20,
            MinEffectiveDistance = 5,
            Name = "N",
            PassabilityPenalty = 0,
            Weight = 1,
            NoiseDistance = 100
        };
        weapon = new RangedWeapon(builder);
    }

    [Test]
    public void GetAccuracy_DistanceLessHalfMin_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(1.3);
        Assert.That(accuracy, Is.EqualTo(0));
    }
    [Test]
    public void GetAccuracy_DistanceEqualHalfMin_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(2.5);
        Assert.That(accuracy, Is.EqualTo(0).Within(.0001));
    }
    [Test]
    public void GetAccuracy_DistanceBetweenHalfMinAndMin_ValueIncreases()
    {
        var accuracy1 = weapon.GetAccuracy(3.5);
        var accuracy2 = weapon.GetAccuracy(4.5);
        
        Assert.That(accuracy1, Is.LessThan(accuracy2));
    }
    [Test]
    public void GetAccuracy_DistanceEqualsMin_ReturnsBaseAccuracy()
    {
        var accuracy = weapon.GetAccuracy(5);
        
        Assert.That(accuracy, Is.EqualTo(builder.BaseAccuracy).Within(.0001));
    }
    [Test]
    public void GetAccuracy_DistanceBetweenMinAndMax_ReturnsBaseAccuracy()
    {
        var accuracy = weapon.GetAccuracy(6.8);
        
        Assert.That(accuracy, Is.EqualTo(builder.BaseAccuracy).Within(.0001));
    }
    [Test]
    public void GetAccuracy_DistanceEqualsMax_ReturnsBaseAccuracy()
    {
        var accuracy = weapon.GetAccuracy(20);
        
        Assert.That(accuracy, Is.EqualTo(builder.BaseAccuracy).Within(.0001));
    }
    [Test]
    public void GetAccuracy_DistanceBetweenMaxAndOneAndHalfMax_ValueDecreases()
    {
        var accuracy1 = weapon.GetAccuracy(22);
        var accuracy2 = weapon.GetAccuracy(25.5);
        
        Assert.That(accuracy1, Is.GreaterThan(accuracy2));
    }
    [Test]
    public void GetAccuracy_DistanceEqualsOneAndHalfMax_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(30);
        
        Assert.That(accuracy, Is.EqualTo(0).Within(.0001));
    }
    [Test]
    public void GetAccuracy_DistanceGreaterOneAndHalfMax_ReturnsZero()
    {
        var accuracy = weapon.GetAccuracy(35);
        
        Assert.That(accuracy, Is.EqualTo(0).Within(.0001));
    }
}
