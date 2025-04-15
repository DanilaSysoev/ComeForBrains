using System.Text.Json;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public class JsonFilesLocationBuilder : ILocationBuilder
{
    public JsonFilesLocationBuilder(string pathToFiles)
    {
        mapBuilder = new TextFileMapBuilder(Path.Combine(pathToFiles, "Map"));
        locationDataProvider = new FromFileJsonProvider(
            Path.Combine(pathToFiles, "Location.json")
        );
    }
    public JsonFilesLocationBuilder(
        IMapBuilder mapBuilder,
        IJsonProvider locationDataProvider
    )
    {
        this.mapBuilder = mapBuilder;
        this.locationDataProvider = locationDataProvider;
    }

    public Map BuildMap()
    {
        return new Map(mapBuilder);
    }

    public string BuildName()
    {
        var locationDescriptor = JsonSerializer.Deserialize<LocationDescriptor>(
            locationDataProvider.GetJson()
        );
        if(locationDescriptor is null)
            throw new InvalidOperationException("No location descriptors found");
        return locationDescriptor.Name;
    }

    private sealed class LocationDescriptor
    {
        public string Name { get; set; } = "";
    }

    private readonly IMapBuilder mapBuilder;
    private readonly IJsonProvider locationDataProvider;
}
