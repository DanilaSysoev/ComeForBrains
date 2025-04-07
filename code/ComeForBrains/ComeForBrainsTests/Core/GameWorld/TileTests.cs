using ComeForBrains.Core;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;

namespace ComeForBrainsTests.Core.GameWorld;

[TestFixture]
public class TileTests : Tests
{
    class DummyItem : Item
    {
        public DummyItem() : base("Dummy", "", 10, 5)
        {
        }

        public override void Interact(GameContext context)
        {}
    }

    private Tile tile = null!;
    private Item item = null!;
    private Item item1 = null!;
    private Item item2 = null!;
    private Container container = null!;
    private Item storedItem = null!;

    [SetUp]
    public void Setup()
    {
        tile = new Tile("T1", "D1", 75);
        item = new DummyItem();
        item1 = new DummyItem();
        item2 = new DummyItem();

        container = new Container("C1", "D1", 75, 20);
        storedItem = new DummyItem();
        container.Add(storedItem);
    }


    [Test]
    public void Create_EmptyTile_PassabilityEqualsBaseWeight()
    {
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
    [Test]
    public void Create_EmptyContainer_CountEqualsZero()
    {
        Assert.That(tile.CountOfItems, Is.EqualTo(0));
    }

    [Test]
    public void Add_OneItem_PassabilityEqualsBaseMinusItemPenalty()
    {
        tile.Place(item);
        Assert.That(tile.Passability, Is.EqualTo(70));
    }
    [Test]
    public void Add_OneItem_CountEqualsOne()
    {
        tile.Place(item);
        Assert.That(tile.CountOfItems, Is.EqualTo(1));
    }
    [Test]
    public void Add_TwoItem_PassabilityEqualsBaseMinusSumOfAllPenalties()
    {
        tile.Place(item1);
        tile.Place(item2);
        Assert.That(tile.Passability, Is.EqualTo(65));
    }
    [Test]
    public void Add_TwoItem_CountEqualsTwo()
    {
        tile.Place(item1);
        tile.Place(item2);
        Assert.That(tile.CountOfItems, Is.EqualTo(2));
    }
    [Test]
    public void Add_AddNoneEmptyContainer_PassabilityEqualsBaseMinusContainerPenalty()
    {
        tile.Place(container);
        Assert.That(tile.Passability, Is.EqualTo(55));
    }
    [Test]
    public void Add_AddStoredItem_PassabilityEqualsBaseMinusContainerPenalty()
    {
        tile.Place(container);
        tile.Place(storedItem);
        Assert.That(tile.Passability, Is.EqualTo(55));
    }


    [Test]
    public void Remove_OneItemThenRemove_WeightEqualsBaseWeight()
    {
        tile.Place(item);
        tile.Remove(item);
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
    [Test]
    public void Remove_OneItemThenRemove_CountEqualsZero()
    {
        tile.Place(item);
        tile.Remove(item);
        Assert.That(tile.CountOfItems, Is.EqualTo(0));
    }
    [Test]
    public void Remove_TwoItemThenRemoveOne_CountEqualsOne()
    {
        tile.Place(item1);
        tile.Place(item2);
        tile.Remove(item1);
        Assert.That(tile.CountOfItems, Is.EqualTo(1));
    }
    [Test]
    public void Remove_TwoItemThenRemoveOne_WeightEqualsBasePlusOneItem()
    {
        tile.Place(item1);
        tile.Place(item2);
        tile.Remove(item1);
        Assert.That(tile.Passability, Is.EqualTo(70));
    }
    [Test]
    public void Remove_TwoItemThenRemoveTwo_WeightEqualsBase()
    {
        tile.Place(item1);
        tile.Place(item2);
        tile.Remove(item1);
        tile.Remove(item2);
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
    [Test]
    public void Remove_AddNoneEmptyContainerThenRemove_PassabilityEqualsBase()
    {
        tile.Place(container);
        tile.Remove(container);
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
    [Test]
    public void Remove_AddStoredItemThenRemove_PassabilityEqualsBaseMinusContainerPenalty()
    {
        tile.Place(container);
        tile.Place(storedItem);
        tile.Remove(storedItem);
        Assert.That(tile.Passability, Is.EqualTo(55));
    }
    [Test]
    public void Remove_NotExistentItem_PassabilityEqualsBase()
    {
        tile.Remove(item);
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
    [Test]
    public void Remove_NotExistentStoredItem_PassabilityEqualsBase()
    {
        tile.Remove(storedItem);
        Assert.That(tile.Passability, Is.EqualTo(75));
    }
}
