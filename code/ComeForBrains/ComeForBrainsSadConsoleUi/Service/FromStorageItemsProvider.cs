using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Service;

public class FromStorageItemsProvider<TItem> : IItemsProvider
    where TItem : Item
{
    public IEnumerable<Item> GetItems()
    {
        return Environment.Instance.Context.Camp.GetFromStorage<TItem>();
    }
}
