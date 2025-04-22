using ComeForBrains.Core;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Service;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Mechanics;

[TestFixture]
public class RandomExternalPrioritizedCampDamageDistributorTests : Tests
{
    private Camp camp = null!;
    private GameContext gameContext = null!;

    private CampElement ce1 = null!;
    private CampElement ce2 = null!;
    private CampElement ce3 = null!;

    [SetUp]
    public void Setup()
    {
        gameContext = new GameContext(
            new PersonContextBuilder(
                new ComeForBrains.Core.Characters.Person(
                    new DummyPersonBuilder()
                )
            )
        );
        camp = gameContext.Camp;

        ce1 = new CampElement(
            new CampElementBuilder {
                FortificationValue = 100,
                ComfortValue = 90,
                Strength = 100,
                MaxStrength = 100,
                ElementTypeName = "External"
            }
        );
        ce2 = new CampElement(
            new CampElementBuilder {
                FortificationValue = 50,
                ComfortValue = 30,
                Strength = 100,
                MaxStrength = 100,
                ElementTypeName = "External"
            }
        );
        ce3 = new CampElement(
            new CampElementBuilder {
                FortificationValue = 50,
                ComfortValue = 30,
                Strength = 100,
                MaxStrength = 100,
                ElementTypeName = "Internal"
            }
        );

        camp.SetupCampElement(ce1);
        camp.SetupCampElement(ce2);
        camp.SetupCampElement(ce3);
    }

    [Test]
    public void CalculateDamage_RandomIs02_AllDamageToFirst()
    {
        RandomProvider.Initialize(new AlwaysPredeclaredRandom(.2));
        var damageDistributor =
            new RandomExternalPrioritizedCampDamageDistributor(gameContext, 10);
        
        Assert.That(ce1.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce2.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce3.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce1), Is.EqualTo(10).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce2), Is.EqualTo(0).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce3), Is.EqualTo(0).Within(0.0001));
    }
    [Test]
    public void CalculateDamage_RandomIs05_DamageEqualBetweenTwo()
    {
        RandomProvider.Initialize(new AlwaysPredeclaredRandom(.5));
        var damageDistributor =
            new RandomExternalPrioritizedCampDamageDistributor(gameContext, 10);
        
        Assert.That(ce1.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce2.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce3.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce1), Is.EqualTo(5).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce2), Is.EqualTo(5).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce3), Is.EqualTo(0).Within(0.0001));
    }
    [Test]
    public void CalculateDamage_RandomIs0493_DamageBetweenTwo()
    {
        RandomProvider.Initialize(new AlwaysPredeclaredRandom(.493));
        var damageDistributor =
            new RandomExternalPrioritizedCampDamageDistributor(gameContext, 10);
        
        Assert.That(ce1.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce2.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce3.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce1), Is.EqualTo(6).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce2), Is.EqualTo(4).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce3), Is.EqualTo(0).Within(0.0001));
    }
    [Test]
    public void CalculateDamage_GreaterThenAllExternal_DamageInternal()
    {
        RandomProvider.Initialize(new AlwaysPredeclaredRandom(.5));
        var damageDistributor =
            new RandomExternalPrioritizedCampDamageDistributor(gameContext, 210);
        
        Assert.That(ce1.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce2.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(ce3.Strength, Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce1), Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce2), Is.EqualTo(100).Within(0.0001));
        Assert.That(damageDistributor.CalculateDamage(ce3), Is.EqualTo(10).Within(0.0001));
    }
}
