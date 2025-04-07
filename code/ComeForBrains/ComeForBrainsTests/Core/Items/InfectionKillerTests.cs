using ComeForBrains.Core;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;
using ComeForBrains.Service;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class InfectionKillerTests : Tests
{
    private GameContext gameContext = null!;
    private Person person = null!;
    private InfectionKiller ic0 = null!;
    private InfectionKiller ic1 = null!;

    [SetUp]
    public void Setup()
    {
        RandomProvider.Initialize(new RangeSuccessRandom(0, 50));

        person = new Person(new DummyPersonBuilder());
        gameContext = new GameContext(
            new PersonContextBuilder(person)
        );
        ic0 = new InfectionKiller("ic0", "d0", 1, 1, 30, 20, 100);
        ic1 = new InfectionKiller("ic1", "d1", 1, 1, 80, 30, 10);

        person.Inventory.AddItem(ic0);
        person.Inventory.AddItem(ic1);

        person.Infect();
    }

    [Test]
    public void KillInfection_LowTimePassedAndChanceOk_PersonNotInfected()
    {
        person.TimePassed(50);
        ic0.Interact(gameContext);
        Assert.That(person.IsInfected, Is.False);
    }
    [Test]
    public void KillInfection_TooManyTimePassedAndChanceOk_PersonInfected()
    {
        person.TimePassed(200);
        ic0.Interact(gameContext);
        Assert.That(person.IsInfected, Is.True);
    }
    [Test]
    public void KillInfection_LowTimePassedAndChanceOk_HealthDamaged()
    {
        var before = person.Health.Value;
        person.TimePassed(50);
        ic0.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before - ic0.HealthDamage));
    }
    [Test]
    public void KillInfection_TooManyTimePassedAndChanceOk_HealthDamaged()
    {
        var before = person.Health.Value;
        person.TimePassed(200);
        ic0.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before - ic0.HealthDamage));
    }

    [Test]
    public void KillInfection_LowTimePassedAndChanceNotOk_PersonInfected()
    {
        person.TimePassed(5);
        ic1.Interact(gameContext);
        Assert.That(person.IsInfected, Is.True);
    }
    [Test]
    public void KillInfection_TooManyTimePassedAndChanceNotOk_PersonInfected()
    {
        person.TimePassed(20);
        ic1.Interact(gameContext);
        Assert.That(person.IsInfected, Is.True);
    }
    [Test]
    public void KillInfection_LowTimePassedAndChanceNotOk_HealthDamaged()
    {
        var before = person.Health.Value;
        person.TimePassed(5);
        ic1.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before - ic1.HealthDamage));
    }
    [Test]
    public void KillInfection_TooManyTimePassedAndChanceNotOk_HealthDamaged()
    {
        var before = person.Health.Value;
        person.TimePassed(20);
        ic1.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before - ic1.HealthDamage));
    }
}
