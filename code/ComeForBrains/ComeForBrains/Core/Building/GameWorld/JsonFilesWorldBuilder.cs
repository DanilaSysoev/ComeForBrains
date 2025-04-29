using System.Text.Json;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public class JsonFilesWorldBuilder : IWorldBuilder
{
    public JsonFilesWorldBuilder(
        string pathToWorldFiles,
        string pathToItemsFiles
    ) {
        settlementBuilders = new();
        var descr = JsonSerializer.Deserialize<WorldDescriptor>(
            new FromFileJsonProvider(
                Path.Combine(pathToWorldFiles, "World.json")
            ).GetJson()
        )!;
        var itemsBuilders = new FromJsonItemBuilders(pathToItemsFiles);
        foreach(var settlementName in descr.Settlements)
        {
            settlementBuilders.Add(
                new JsonFilesSettlementBuilder(
                    Path.Combine(pathToWorldFiles, settlementName),
                    itemsBuilders
                )
            );
        }
    }

    public IEnumerable<Settlement> BuildSettlements()
    {
        return settlementBuilders.Select(s => new Settlement(s));
    }
    
    private sealed class WorldDescriptor
    {
        public List<string> Settlements { get; } = new();
    }

    private readonly List<ISettlementBuilder> settlementBuilders;
}
