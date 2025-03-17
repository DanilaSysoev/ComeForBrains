namespace ComeForBrains.Core;

public class World : GameEntity
{
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
