namespace ComeForBrains.Core.GameWorld;

public class Settlement : NamedEntity
{
    public World World
    {
        get => world;
        internal set => world = value;
    }

    public Settlement(string name,
                      IEnumerable<Location> locations)
        : base(name)
    {
        foreach(var location in locations)
        {
            this.locations.Add(location.Name, location);
            location.Settlement = this;
        }
    }

    public void AddConnection(string settlementName, int distance)
    {
        distances.Add(settlementName, distance);
    }
    public void RemoveConnection(string settlementName)
    {
        distances.Remove(settlementName);
    }
    public bool HasConnection(string settlementName)
    {
        return distances.ContainsKey(settlementName);
    }
    public int GetDistance(string settlementName)
    {
        return distances[settlementName];
    }

    public Location GetLocation(string locationName)
    {
        return locations[locationName];
    }

    private World world = null!;
    private readonly Dictionary<string, int> distances = new();
    private readonly Dictionary<string, Location> locations = new();
}
