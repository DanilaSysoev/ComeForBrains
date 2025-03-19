using ComeForBrains.Core;
using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;

namespace MyGameTests.Core.Items;


public class ContainerTests
{
    class DummyItem : Item
    {
        public DummyItem() : base("Dummy", "", 10, 5)
        {
        }

        public override void Interact(GameContext context)
        {}
    }


    private GameContext context = null!;
    private Tile tile = null!;
    private Container container = null!;
    private Item item = null!;
    private Item item1 = null!;
    private Item item2 = null!;


    [SetUp]
    public void Setup()
    {
        context = new GameContext(
            new Person(new DefaultAttributesBuilder("", 0, 0, 0, 0, 0))
        );
        tile = new Tile("", "");
        container = new Container("container", "", 30, 15, tile);
        item = new DummyItem();
        item1 = new DummyItem();
        item2 = new DummyItem();
    }


    [Test]
    public void Create_EmptyContainer_WeightEqualsBaseWeight()
    {    
        Assert.That(container.Weight, Is.EqualTo(30));
    }
    [Test]
    public void Create_EmptyContainer_CountEqualsZero()
    {    
        Assert.That(container.Count, Is.EqualTo(0));
    }

    [Test]
    public void Add_OneItem_WeightEqualsBaseWeightPlusItemWeight()
    {
        container.Add(item);
        Assert.That(container.Weight, Is.EqualTo(40));
    }
    [Test]
    public void Add_OneItem_CountEqualsOne()
    {
        container.Add(item);
        Assert.That(container.Count, Is.EqualTo(1));
    }
    [Test]
    public void Add_TwoItem_WeightEqualsSumOfAll()
    {
        container.Add(item1);
        container.Add(item2);
        Assert.That(container.Weight, Is.EqualTo(50));
    }
    [Test]
    public void Add_TwoItem_CountEqualsTwo()
    {
        container.Add(item1);
        container.Add(item2);
        Assert.That(container.Count, Is.EqualTo(2));
    }
    [Test]
    public void Add_OneItem_ContainerOfItemSetCorrectly()
    {
        container.Add(item);
        Assert.That(item.Container, Is.SameAs(container));
    }
    [Test]
    public void Add_OneItem_StoredOfItemIsTrue()
    {
        container.Add(item);
        Assert.That(item.Stored, Is.True);
    }
    

    [Test]
    public void Remove_OneItemThenRemove_WeightEqualsBaseWeight()
    {
        container.Add(item);
        container.Remove(item);
        Assert.That(container.Weight, Is.EqualTo(30));
    }
    [Test]
    public void Remove_OneItemThenRemove_CountEqualsZero()
    {
        container.Add(item);
        container.Remove(item);
        Assert.That(container.Count, Is.EqualTo(0));
    }
    [Test]
    public void Remove_TwoItemThenRemoveOne_CountEqualsOne()
    {
        container.Add(item1);
        container.Add(item2);
        container.Remove(item1);
        Assert.That(container.Count, Is.EqualTo(1));
    }
    [Test]
    public void Remove_TwoItemThenRemoveOne_WeightEqualsBasePlusOneItem()
    {
        container.Add(item1);
        container.Add(item2);
        container.Remove(item1);
        Assert.That(container.Weight, Is.EqualTo(40));
    }
    [Test]
    public void Remove_TwoItemThenRemoveTwo_WeightEqualsBase()
    {
        container.Add(item1);
        container.Add(item2);
        container.Remove(item1);
        container.Remove(item2);
        Assert.That(container.Weight, Is.EqualTo(30));
    }
    [Test]
    public void Remove_OneItemThenRemove_ContainerOfItemIsNull()
    {
        container.Add(item);
        container.Remove(item);
        Assert.That(item.Container, Is.Null);
    }
    [Test]
    public void Remove_OneItemThenRemove_StoredOfItemIsFalse()
    {
        container.Add(item);
        container.Remove(item);
        Assert.That(item.Stored, Is.False);
    }
    [Test]
    public void Remove_RemoveNonExistentItem_WeightEqualsBaseWeight()
    {
        container.Remove(item);
        Assert.That(container.Weight, Is.EqualTo(30));
    }

    [Test]
    public void Interact_TwoItemsInContainer_BothAddToTile()
    {
        container.Add(item1);
        container.Add(item2);
        container.Interact(context);
        Assert.That(tile.Contains(item1));
        Assert.That(tile.Contains(item2));
    }
    [Test]
    public void Interact_TwoItemsInContainer_TilePassabilityNotChanged()
    {
        var old = tile.Passability;
        container.Add(item1);
        container.Add(item2);
        container.Interact(context);
        Assert.That(old, Is.EqualTo(tile.Passability));
    }
    [Test]
    public void Interact_InteractTwoTimes_ItemsNotInTile()
    {
        container.Add(item1);
        container.Add(item2);
        container.Interact(context);
        container.Interact(context);
        Assert.That(!tile.Contains(item1));
        Assert.That(!tile.Contains(item2));
    }
}
