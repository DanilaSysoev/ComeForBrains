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
        itemsInfo = new Dictionary<string, IJsonProvider>();
        CreateBuilders(pathToFiles, settlementDescr);
        this.itemsBuilders = itemsBuilders;
    }
    public JsonFilesSettlementBuilder(
        IJsonProvider settlementInfo,
        IDictionary<string, IMapBuilder> mapBuilders,
        IDictionary<string, IJsonProvider> locationInfo,
        IDictionary<string, IJsonProvider> itemsInfo,
        IItemsBuilders itemsBuilders
    ) {
        this.settlementInfo = settlementInfo;
        this.mapBuilders = mapBuilders;
        this.locationInfo = locationInfo;
        this.itemsInfo = itemsInfo;
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
                                locationInfo[locationName],
                                itemsInfo[locationName]
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

    public double BuildDistanceToCamp()
    {
        return JsonSerializer.Deserialize<SettlementDescriptor>(
            settlementInfo.GetJson()
        )!.DistanceToCamp;
    }


    private sealed class SettlementDescriptor
    {
        public string Name { get; set; } = "";
        public string[] Locations { get; set; } = Array.Empty<string>();
        public double DistanceToCamp { get; set; } = 0;
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
            itemsInfo.Add(
                locationName,
                new FromFileJsonProvider(
                    Path.Combine(pathToFiles, locationName, "Items.json")
                )
            );
        }
    }

    private readonly IItemsBuilders itemsBuilders;
    private readonly IJsonProvider settlementInfo;
    private readonly IDictionary<string, IMapBuilder> mapBuilders;
    private readonly IDictionary<string, IJsonProvider> locationInfo;
    private readonly IDictionary<string, IJsonProvider> itemsInfo;
}
