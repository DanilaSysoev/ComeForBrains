using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrains.Core.GameWorld;

public class Settlement : DescribedEntity
{
    public World World
    {
        get => world;
        internal set => world = value;
    }

    public double DistanceToCamp { get; internal set; }

    public Settlement(ISettlementBuilder builder)
        : base(builder.BuildName(), builder.BuildDescription())
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
        string description,
        double distanceToCamp,
        IEnumerable<Location> locations
    ) : base(name, description)
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
