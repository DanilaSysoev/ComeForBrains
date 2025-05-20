using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.GameWorld;

public class Location : DescribedEntity
{
    public Map Map { get; private set; }

    public Settlement Settlement
    {
        get => settlement;
        internal set => settlement = value;
    }

    public Location(ILocationBuilder builder, IItemsBuilders itemsBuilders)
        : base(builder.BuildName(), builder.BuildDescription())
    {
        Map = builder.BuildMap();
        builder.PlaceItems(Map, itemsBuilders);
    }

    public Location(
        string name,
        string description,
        Map map
    ) : base(name, description)
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
    public override string ToString()
    {
        return Name;
    }

    private Settlement settlement = null!;
}
