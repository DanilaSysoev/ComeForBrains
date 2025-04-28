using System.Text.Json;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public class JsonFilesSettlementBuilder : ISettlementBuilder
{
    public JsonFilesSettlementBuilder(
        string pathToFiles,
        IItemsBuilders itemsBuilders
    )
    {
        settlementInfo = new FromFileJsonProvider(
            Path.Combine(pathToFiles, "Settlement.json")
        );
        var settlementDescr =
            JsonSerializer.Deserialize<SettlementDescriptor>(
                settlementInfo.GetJson()
            )!;
        mapBuilders = new Dictionary<string, IMapBuilder>();
        locationInfo = new Dictionary<string, IJsonProvider>();
        CreateBuilders(pathToFiles, settlementDescr);
        this.itemsBuilders = itemsBuilders;
    }
    public JsonFilesSettlementBuilder(
        IJsonProvider settlementInfo,
        IDictionary<string, IMapBuilder> mapBuilders,
        IDictionary<string, IJsonProvider> locationInfo,
        IItemsBuilders itemsBuilders
    ) {
        this.settlementInfo = settlementInfo;
        this.mapBuilders = mapBuilders;
        this.locationInfo = locationInfo;
        this.itemsBuilders = itemsBuilders;
    }

    public IEnumerable<Location> BuildLocations()
    {
        var descr = JsonSerializer.Deserialize<SettlementDescriptor>(
            settlementInfo.GetJson()
        )!;
        return descr.Locations
                    .Select(
                        locationName => new Location(
                            new JsonFilesLocationBuilder(
                                mapBuilders[locationName],
                                locationInfo[locationName]
                            ),
                            itemsBuilders
                        )
                    );
    }

    public string BuildName()
    {
        return JsonSerializer.Deserialize<SettlementDescriptor>(
            settlementInfo.GetJson()
        )!.Name;
    }

    public void AddConnections(Settlement settlement)
    {
        var descr = JsonSerializer.Deserialize<SettlementDescriptor>(
            settlementInfo.GetJson()
        )!;
        foreach (var (settlementName, distance) in descr.Connections)
            settlement.AddConnection(settlementName, distance);
    }


    private sealed class SettlementDescriptor
    {
        public string Name { get; set; } = "";
        public string[] Locations { get; set; } = Array.Empty<string>();
        public Dictionary<string, int> Connections { get; set; } = new();
    }

    private void CreateBuilders(string pathToFiles, SettlementDescriptor settlementDescr)
    {
        foreach (var locationName in settlementDescr.Locations)
        {
            mapBuilders.Add(
                locationName,
                new TextFileMapBuilder(
                    Path.Combine(pathToFiles, locationName, "Map")
                )
            );
            locationInfo.Add(
                locationName,
                new FromFileJsonProvider(
                    Path.Combine(pathToFiles, locationName, "Location.json")
                )
            );
        }
    }

    private readonly IItemsBuilders itemsBuilders;
    private readonly IJsonProvider settlementInfo;
    private readonly IDictionary<string, IMapBuilder> mapBuilders;
    private readonly IDictionary<string, IJsonProvider> locationInfo;
}
