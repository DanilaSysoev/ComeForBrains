using System.Text.Json;

namespace ComeForBrains.Core.Building;

internal class ItemsStorageDescriptorBuilder
{
    internal ItemsStorageDescriptorBuilder(IJsonProvider json)
    {
        this.json = json;
    }

    public ItemsStorageDescriptor Build()
    {
        return JsonSerializer.Deserialize<ItemsStorageDescriptor>(
            json.GetJson()
        ) ?? new();
    }

    private readonly IJsonProvider json;
}
