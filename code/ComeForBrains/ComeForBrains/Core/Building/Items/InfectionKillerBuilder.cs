using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class InfectionKillerBuilder : ItemBuilder
{
    public double SuccessChance { get; set; }
    public double HealthDamage { get; set; }
    public double EffectiveTime { get; set; }

    public override Item Build()
    {
        return new InfectionKiller(this);
    }
}
