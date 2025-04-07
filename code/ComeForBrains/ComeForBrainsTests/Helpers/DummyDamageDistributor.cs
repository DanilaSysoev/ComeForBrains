using ComeForBrains.Core;
using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrainsTests.Helpers;

public class DummyDamageDistributor : ICampDamageDistributor
{
    private readonly double totalDamage;

    public DummyDamageDistributor(GameContext _, double totalDamage)
    {
        this.totalDamage = totalDamage;
    }

    public double CalculateDamage(CampElement campElement)
    {
        return totalDamage;
    }
}
