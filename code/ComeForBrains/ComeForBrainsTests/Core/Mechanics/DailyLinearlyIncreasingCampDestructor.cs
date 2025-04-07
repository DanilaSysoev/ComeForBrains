using System;
using ComeForBrains.Core;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Core.Mechanics.Base;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Mechanics;

[TestFixture]
public class DailyLinearlyIncreasingCampDestructorTests : Tests
{
    private ICampDestructor campDestructor = null!;
    private Camp camp = null!;
    private GameContext gameContext = null!;

    private CampElement ce1 = null!;
    private CampElement ce2 = null!;

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
        campDestructor = camp.Destructor;

        ce1 = new CampElement(
            new CampElementBuilder {
                FortificationValue = 100,
                ComfortValue = 90,
                Srength = 100,
                MaxSrength = 100
            }
        );
        ce2 = new CampElement(
            new CampElementBuilder {
                FortificationValue = 50,
                ComfortValue = 30,
                Srength = 100,
                MaxSrength = 100
            }
        );

        camp.SetupCampElement(ce1);
        camp.SetupCampElement(ce2);
    }

    [Test]
    public void DamageCamp_ZeroDay_DamageEqualBase()
    {
        campDestructor.DamageCamp(gameContext);
        Assert.That(ce1.Fortification, Is.EqualTo(90).Within(.00001));
        Assert.That(ce2.Fortification, Is.EqualTo(45).Within(.00001));
        Assert.That(ce1.Comfort, Is.EqualTo(81).Within(.00001));
        Assert.That(ce2.Comfort, Is.EqualTo(27).Within(.00001));
    }

    [Test]
    public void DamageCamp_OneDay_DamageEqualBasePlusOneIncreasing()
    {
        gameContext.GoToNextDay();
        campDestructor.DamageCamp(gameContext);
        Assert.That(ce1.Fortification, Is.EqualTo(85).Within(.00001));
        Assert.That(ce2.Fortification, Is.EqualTo(42.5).Within(.00001));
        Assert.That(ce1.Comfort, Is.EqualTo(76.5).Within(.00001));
        Assert.That(ce2.Comfort, Is.EqualTo(25.5).Within(.00001));
    }
}
