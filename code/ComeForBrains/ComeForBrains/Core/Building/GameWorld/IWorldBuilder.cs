
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface IWorldBuilder
{
    IEnumerable<Settlement> BuildSettlements();
}
