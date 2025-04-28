
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface ISettlementBuilder
{
    IEnumerable<Location> BuildLocations();
    string BuildName();
    void AddConnections(Settlement settlement);
}
