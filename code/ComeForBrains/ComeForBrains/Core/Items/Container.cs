using System.Collections;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Items;

public class Container : Item, IEnumerable<Item>
{
    public override double Weight => totalWeigth;
    public Tile? Tile { get; init; }

    public Container(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        Tile? tile = null
    ) : base(name, description, weight, passabilityPenalty)
    {
        totalWeigth = weight;

        Tile = tile;
        if (Tile is not null)
            Tile.Place(this);
    }
    public Container(ContainerBuilder builder)
        : base(builder)
    {
        totalWeigth = builder.Weight;
    }

    public override void Interact(GameContext context)
    {
        if (Tile is null)
            return;

        if(isOpened)
            Pack();
        else
            Unpack();
    }

    public int Count => items.Count;
    public void Add(Item item)
    {
        items.Add(item);
        totalWeigth += item.Weight;
        item.Container = this;
    }
    public void Remove(Item item)
    {
        if(items.Remove(item))
        {
            totalWeigth -= item.Weight;
            item.Container = null;
        }
    }
    public bool Contains(Item item)
    {
        return items.Contains(item);
    }
    public IEnumerator<Item> GetEnumerator()
    {
        return items.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Pack()
    {
        foreach(var item in items)
            Tile!.Remove(item);

        isOpened = false;
    }
    private void Unpack()
    {
        foreach(var item in items)
            Tile!.Place(item);

        isOpened = true;
    }

    private double totalWeigth;
    private bool isOpened = false;
    private readonly List<Item> items = new();
}
