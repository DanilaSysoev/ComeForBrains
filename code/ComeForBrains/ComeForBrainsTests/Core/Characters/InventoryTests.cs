using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;

namespace ComeForBrainsTests.Core.Characters;

public class InventoryTests
{
    private Inventory inventory = null!;
    private Medicine m1 = null!;
    private Medicine m2 = null!;
    private Container c1 = null!;

    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
        m1 = new Medicine("m1", "", 1, 10, 1);
        m2 = new Medicine("m2", "", 2, 20, 2);
        c1 = new Container("c1", "", 3, 30);
    }

    [Test]
    public void AddItem_AddOneItem_CountOfItemEqualsOne()
    {
        inventory.AddItem(m1);
        Assert.That(inventory.Count, Is.EqualTo(1));
    }
    [Test]
    public void AddItem_AddOneItem_CountOfItemOfThisTypeEqualsOne()
    {
        inventory.AddItem(m1);
        Assert.That(inventory.GetItemCount<Medicine>(), Is.EqualTo(1));
    }
    [Test]
    public void AddItem_AddOneItem_CountOfItemOfOtherTypeEqualsZero()
    {
        inventory.AddItem(m1);
        Assert.That(inventory.GetItemCount<Container>(), Is.EqualTo(0));
    }
    [Test]
    public void AddItem_AddTwoItems_CountOfItemEqualsTwo()
    {
        inventory.AddItem(m1);
        inventory.AddItem(m2);
        Assert.That(inventory.Count, Is.EqualTo(2));
    }
    [Test]
    public void AddItem_AddTwoSameTypesItems_CountOfItemOfThisTypeEqualsTwo()
    {
        inventory.AddItem(m1);
        inventory.AddItem(m2);
        Assert.That(inventory.GetItemCount<Medicine>(), Is.EqualTo(2));
    }
    [Test]
    public void AddItem_AddTwoSameTypesItems_CountOfItemOfOtherTypeEqualsZero()
    {
        inventory.AddItem(m1);
        inventory.AddItem(m2);
        Assert.That(inventory.GetItemCount<Container>(), Is.EqualTo(0));
    }
    [Test]
    public void AddItem_AddTwoItemsOfDifferentTypes_CountOfItemEqualsTwo()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        Assert.That(inventory.Count, Is.EqualTo(2));
    }
    [Test]
    public void AddItem_AddTwoItemsOfDifferentTypes_CountOfItemOfFirstTypeEqualsOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        Assert.That(inventory.GetItemCount<Medicine>(), Is.EqualTo(1));
    }
    [Test]
    public void AddItem_AddTwoItemsOfDifferentTypes_CountOfItemOfSecondTypeEqualsOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        Assert.That(inventory.GetItemCount<Container>(), Is.EqualTo(1));
    }
    [Test]
    public void AddItem_AddTwoItems_WeightEqualsSumOfWeights()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        Assert.That(inventory.Weight, Is.EqualTo(m1.Weight + c1.Weight).Within(0.00001));
    }


    [Test]
    public void RemoveItem_AddTwoItemsOfDifferentTypesThenRemoveFirst_CountOfItemEqualsOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m1);
        Assert.That(inventory.Count, Is.EqualTo(1));
    }
    [Test]
    public void RemoveItem_AddTwoItemsOfDifferentTypesThenRemoveFirst_CountOfItemOfFirstTypeEqualsZero()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m1);
        Assert.That(inventory.GetItemCount<Medicine>(), Is.EqualTo(0));
    }
    [Test]
    public void RemoveItem_AddTwoItemsOfDifferentTypesThenRemoveFirst_CountOfItemOfSecondTypeEqualsOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m1);
        Assert.That(inventory.GetItemCount<Container>(), Is.EqualTo(1));
    }
    [Test]
    public void RemoveItem_AddTwoItemsThenRemoveFirst_WeightEqualsSecondItemWeight()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m1);
        Assert.That(inventory.Weight, Is.EqualTo(c1.Weight).Within(0.00001));
    }
    [Test]
    public void RemoveItem_AddTwoItemsThenRemoveNotExistent_WeightEqualsSumOfTwo()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m2);
        Assert.That(inventory.Weight, Is.EqualTo(c1.Weight + m1.Weight).Within(0.00001));
    }
    [Test]
    public void RemoveItem_AddTwoItemsThenRemoveNotExistent_CountOfItemsEqualTwo()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m2);
        Assert.That(inventory.Count, Is.EqualTo(2));
    }
    [Test]
    public void RemoveItem_AddTwoItemsThenRemoveNotExistent_CountOfFirstTypeItemsEqualOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m2);
        Assert.That(inventory.GetItemCount<Medicine>, Is.EqualTo(1));
    }
    [Test]
    public void RemoveItem_AddTwoItemsThenRemoveNotExistent_CountOfSecondTypeItemsEqualOne()
    {
        inventory.AddItem(m1);
        inventory.AddItem(c1);
        inventory.RemoveItem(m2);
        Assert.That(inventory.GetItemCount<Container>, Is.EqualTo(1));
    }
}
