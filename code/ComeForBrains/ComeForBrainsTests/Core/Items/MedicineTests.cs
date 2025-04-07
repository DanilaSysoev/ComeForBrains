using ComeForBrains.Core;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class MedicineTests : Tests
{
    private GameContext gameContext = null!;
    private Person person = null!;
    private Medicine m0 = null!;
    private Medicine m1 = null!;
    private Medicine m2 = null!;

    [SetUp]
    public void Setup()
    {
        person = new Person(new DummyPersonBuilder());
        gameContext = new GameContext(
            new PersonContextBuilder(person)
        );
        m0 = new Medicine("m0", "d0", 1, 10, 0);
        m1 = new Medicine("m1", "d1", 1, 10, 1);
        m2 = new Medicine("m2", "d2", 1, 10, 4);

        person.Inventory.AddItem(m0);
        person.Inventory.AddItem(m1);
        person.Inventory.AddItem(m2);

        person.Health.Value = 50;        
    }

    [Test]
    public void Interact_ApplyToPersonWithLessHealth_HealPerson()
    {
        var before = person.Health.Value;
        m1.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before + m1.HealingPower));
    }
    [Test]
    public void Interact_ApplyToPersonWithLessHealth_CountDecreaseByOne()
    {
        var before = m2.Count;
        m2.Interact(gameContext);
        Assert.That(m2.Count, Is.EqualTo(before - 1));
    }
    [Test]
    public void Interact_ApplyToPersonWithFullHealth_NotHealPerson()
    {
        person.Health.Value = person.Health.MaxValue;
        m1.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(person.Health.MaxValue));
    }
    [Test]
    public void Interact_ApplyToPersonWithFullHealthWhenZeroCount_NotHealPerson()
    {
        var before = person.Health.Value;
        m0.Interact(gameContext);
        Assert.That(person.Health.Value, Is.EqualTo(before));
    }
    [Test]
    public void Interact_ApplyToPersonWithOneCount_RemoveFromInventory()
    {
        m1.Interact(gameContext);
        Assert.That(person.Inventory.AllItems, Is.Not.Contain(m1));
    }
}
