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

    public override ItemBuilder Copy()
    {
        return new InfectionKillerBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            SuccessChance = SuccessChance,
            HealthDamage = HealthDamage,
            EffectiveTime = EffectiveTime
        };
    }
}
