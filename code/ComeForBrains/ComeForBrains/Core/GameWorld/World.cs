using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrains.Core.GameWorld;

public class World : GameEntity
{
    public World(IWorldBuilder builder)
    {
        foreach(var settlement in builder.BuildSettlements())
        {
            settlements.Add(settlement.Name, settlement);
            settlement.World = this;
        }
    }

    public World(IEnumerable<Settlement> settlements)
    {
        foreach(var settlement in settlements)
        {
            this.settlements.Add(settlement.Name, settlement);
            settlement.World = this;
        }
    }

    public Settlement GetSettlement(string settlementName)
    {
        return settlements[settlementName];
    }

    private readonly Dictionary<string, Settlement> settlements = new();
}
