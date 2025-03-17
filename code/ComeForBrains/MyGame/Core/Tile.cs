using ComeForBrains.Core.Items;

namespace ComeForBrains.Core;

public class Tile : DescribedEntity
{
    public int PercentOfPassability { get; internal set; }
    
    public Tile(
        string name,
        string description,
        int percentOfPassability = HundredPercent
    ) : base(name, description)
    {
        PercentOfPassability = percentOfPassability;
    }

    public void Place(Item item)
    {
        items.Add(item);
        if(!item.Stored)
            PercentOfPassability -= item.PassabilityPenalty;
    }
    public void Remove(Item item)
    {
        if(items.Remove(item) && !item.Stored)
            PercentOfPassability += item.PassabilityPenalty;
    }
    public bool Contains(Item item)
    {
        return items.Contains(item);
    }
    public IEnumerable<Item> Items { get => items; }
    public int CountOfItems => items.Count;

    private readonly List<Item> items = new();

    private const int HundredPercent = 100;
}
