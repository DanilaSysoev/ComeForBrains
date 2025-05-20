using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrains.Core.GameWorld;

public class Settlement : NamedEntity
{
    public World World
    {
        get => world;
        internal set => world = value;
    }

    public double DistanceToCamp { get; internal set; }

    public Settlement(ISettlementBuilder builder)
        : base(builder.BuildName())
    {
        DistanceToCamp = builder.BuildDistanceToCamp();
        foreach(var location in builder.BuildLocations())
        {
            locations.Add(location.Name, location);
            location.Settlement = this;
        }
    }

    public Settlement(
        string name,
        double distanceToCamp,
        IEnumerable<Location> locations
    ) : base(name)
    {
        DistanceToCamp = distanceToCamp;        
        foreach(var location in locations)
        {
            this.locations.Add(location.Name, location);
            location.Settlement = this;
        }
    }

    public Location GetLocation(string locationName)
    {
        return locations[locationName];
    }

    private World world = null!;
    private readonly Dictionary<string, Location> locations = new();
}
