using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public interface ILocationBuilder
{
    Map BuildMap();
    string BuildName();
}
