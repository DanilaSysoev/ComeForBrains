using ComeForBrains.Core;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;
using ComeForBrains.Exceptions;
using ComeForBrains;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Core.Items;

[TestFixture]
public class ArmorTests : Tests
{
    private GameContext gameContext = null!;
    private Person person = null!;
    private Armor a0 = null!;
    private Armor a1 = null!;

    [SetUp]
    public void SetUp()
    {
        person = new Person(new DummyPersonBuilder());
        gameContext = new GameContext(
            new PersonContextBuilder(person)
        );
        
        a0 = new Armor(
            "a0", "d0", 1, 1,
            new List<BodyPart> { BodyPart.Head,
                                 BodyPart.Face,
                                 BodyPart.Neck },
            0.8, 0.8, 10, 1);
        a1 = new Armor(
            "a1", "d1", 2, 2,
            new List<BodyPart> { BodyPart.Neck,
                                 BodyPart.Back,
                                 BodyPart.Chest,
                                 BodyPart.Shoulders,
                                 BodyPart.Stomach },
            GameSettings.MaxArmorThikness - 0.7, 0.2, 5, 0);
        
        person.Inventory.AddItem(a0);
        person.Inventory.AddItem(a1);
    }

    [Test]
    public void Interact_EquipOneItem_ThicknessChangesCorrectly()
    {
        a0.Interact(gameContext);
        Assert.That(person.GetArmorThikness(BodyPart.Head), Is.EqualTo(0.8).Within(0.000001));
        Assert.That(person.GetArmorThikness(BodyPart.Face), Is.EqualTo(0.8).Within(0.000001));
        Assert.That(person.GetArmorThikness(BodyPart.Neck), Is.EqualTo(0.8).Within(0.000001));
        
        Assert.That(person.GetArmorThikness(BodyPart.Shoulders), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Forearms), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Wrists), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Chest), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Back), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Stomach), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Thighs), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Shins), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Feet), Is.EqualTo(0));
    }
    [Test]
    public void Interact_EquipOneItem_ArmorChangesCorrectly()
    {
        a0.Interact(gameContext);
        Assert.That(person.GetArmorValue(BodyPart.Head), Is.EqualTo(10));
        Assert.That(person.GetArmorValue(BodyPart.Face), Is.EqualTo(10));
        Assert.That(person.GetArmorValue(BodyPart.Neck), Is.EqualTo(10));
        
        Assert.That(person.GetArmorValue(BodyPart.Shoulders), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Forearms), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Wrists), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Chest), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Back), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Stomach), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Thighs), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Shins), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Feet), Is.EqualTo(0));
    }
    [Test]
    public void Interact_EquipOneItem_ItemRemovedFromInventory()
    {
        a0.Interact(gameContext);
        Assert.That(person.Inventory.AllItems, Contains.Item(a1));
        Assert.That(person.Inventory.AllItems.Count(), Is.EqualTo(1));
    }
    [Test]
    public void Equip_TryEquipTwoItemsWithTooHighThikness_ExceptionThrown()
    {
        a0.Interact(gameContext);
        Assert.Throws<BadEquipException>(() => person.Equip(a1));
    }

    [Test]
    public void CanEquip_CheckFirst_ReturnsTrue()
    {
        Assert.That(person.CanEquip(a0), Is.True);
    }
    [Test]
    public void CanEquip_CheckSecond_ReturnsFalse()
    {
        a0.Interact(gameContext);
        Assert.That(person.CanEquip(a0), Is.False);
    }

    [Test]
    public void Unequip_EquipThenUneuip_ArmorChangesCorrectly()
    {
        a0.Interact(gameContext);
        person.Unequip(a0);
        Assert.That(person.GetArmorValue(BodyPart.Head), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Face), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Neck), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Shoulders), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Forearms), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Wrists), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Chest), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Back), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Stomach), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Thighs), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Shins), Is.EqualTo(0));
        Assert.That(person.GetArmorValue(BodyPart.Feet), Is.EqualTo(0));
    }
    [Test]
    public void Unequip_EquipThenUneuip_ThiknessChangesCorrectly()
    {
        a0.Interact(gameContext);
        person.Unequip(a0);
        Assert.That(person.GetArmorThikness(BodyPart.Head), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Face), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Neck), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Shoulders), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Forearms), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Wrists), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Chest), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Back), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Stomach), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Thighs), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Shins), Is.EqualTo(0));
        Assert.That(person.GetArmorThikness(BodyPart.Feet), Is.EqualTo(0));
    }
}
