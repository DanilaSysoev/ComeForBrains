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
        ) ??
        throw new InvalidOperationException("No location descriptors found");
    }

    private readonly IJsonProvider json;
}
