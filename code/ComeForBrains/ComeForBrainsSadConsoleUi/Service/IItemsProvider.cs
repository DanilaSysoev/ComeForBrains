using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Service;

public interface IItemsProvider
{
    IEnumerable<Item> GetItems();
}
