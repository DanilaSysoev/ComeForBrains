using ComeForBrains.Core;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class ProvisionTests : Tests
{
    private GameContext gameContext = null!;
    private Person person = null!;
    private Provision p0 = null!;
    private Provision p1 = null!;
    private Provision p2 = null!;
    private Provision p0n = null!;
    private Provision p1n = null!;
    private Provision p2n = null!;

    [SetUp]
    public void SetUp()
    {
        person = new Person(new DummyPersonBuilder());
        gameContext = new GameContext(
            new PersonContextBuilder(person)
        );
        p0 = new Provision("p0", "d0", 1, 1, 10, 0, 0);
        p1 = new Provision("p1", "d1", 1, 1, 0, 10, 0);
        p2 = new Provision("p2", "d2", 1, 1, 0, 0, 10);
        p0n = new Provision("p0", "d0", 1, 1, -10, 0, 0);
        p1n = new Provision("p1", "d1", 1, 1, 0, -10, 0);
        p2n = new Provision("p2", "d2", 1, 1, 0, 0, -10);

        person.Inventory.AddItem(p0);
        person.Inventory.AddItem(p1);
        person.Inventory.AddItem(p2);
        person.Inventory.AddItem(p0n);
        person.Inventory.AddItem(p1n);
        person.Inventory.AddItem(p2n);

        person.Satiety.Value = 50;
        person.Thirst.Value = 50;
        person.Energy.Value = 50;
    }

    [Test]
    public void Interact_ProvisionWithPositiveSatiety_IncreaseSatiety()
    {
        p0.Interact(gameContext);
        Assert.That(person.Satiety.Value, Is.EqualTo(60));
    }
    [Test]
    public void Interact_ProvisionWithNegativeSatiety_DecreaseSatiety()
    {
        p0n.Interact(gameContext);
        Assert.That(person.Satiety.Value, Is.EqualTo(40));
    }
    [Test]
    public void Interact_ProvisionWithPositiveThirst_IncreaseThirst()
    {
        p1.Interact(gameContext);
        Assert.That(person.Thirst.Value, Is.EqualTo(60));
    }
    [Test]
    public void Interact_ProvisionWithNegativeThirst_DecreaseThirst()
    {
        p1n.Interact(gameContext);
        Assert.That(person.Thirst.Value, Is.EqualTo(40));
    }
    [Test]
    public void Interact_ProvisionWithPositiveEnergy_IncreaseEnergy()
    {
        p2.Interact(gameContext);
        Assert.That(person.Energy.Value, Is.EqualTo(60));    
    }
    [Test]
    public void Interact_ProvisionWithNegativeEnergy_DecreaseEnergy()
    {
        p2n.Interact(gameContext);
        Assert.That(person.Energy.Value, Is.EqualTo(40));
    }

    [Test]
    public void Interact_ProvisionInInventory_RemovesItemFromInventory()
    {
        p0.Interact(gameContext);
        Assert.That(person.Inventory.AllItems.Contains(p0), Is.False);
    }
}
