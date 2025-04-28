using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.GameWorld;

public class Location : NamedEntity
{
    public Map Map { get; private set; }

    public Settlement Settlement
    {
        get => settlement;
        internal set => settlement = value;
    }

    public Location(ILocationBuilder builder, IItemsBuilders itemsBuilders)
        : base(builder.BuildName())
    {
        Map = builder.BuildMap();
        builder.PlaceItems(Map, itemsBuilders);
    }

    public Location(string name, Map map) : base(name)
    {
        Map = map;
    }

    public override bool Equals(object? obj)
    {
        return obj is Location location &&
               location.Name == Name &&
               location.Settlement == Settlement;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Settlement.Name);
    }

    private Settlement settlement = null!;
}
