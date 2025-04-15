using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.GameWorld;

public class Tile : DescribedEntity
{
    public double Passability { get; internal set; }
    
    public Tile(
        string name,
        string description,
        double passability = AbsolutePassable
    ) : base(name, description)
    {
        Passability = passability;
    }

    public void Place(Item item)
    {
        items.Add(item);
        if(!item.Stored)
            Passability -= item.PassabilityPenalty;
    }
    public void Remove(Item item)
    {
        if(items.Remove(item) && !item.Stored)
            Passability += item.PassabilityPenalty;
    }
    public bool Contains(Item item)
    {
        return items.Contains(item);
    }
    public IEnumerable<Item> Items { get => items; }
    public int CountOfItems => items.Count;

    private readonly List<Item> items = new();

    private const int AbsolutePassable = 1;
}
