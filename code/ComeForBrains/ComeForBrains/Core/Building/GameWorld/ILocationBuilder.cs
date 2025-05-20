using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface ILocationBuilder
{
    Map BuildMap();
    string BuildName();
    string BuildDescription();
    void PlaceItems(Map map, IItemsBuilders itemsBuilders);
}
