using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class MeleeWeaponBuilder : ItemBuilder
{
    public double BaseDamage { get; set; }
    public double InstantKillChance { get; set; }
    public double BaseAccuracy { get; set; }
    public double EnergyConsumptionModifier { get; set; }
    public double MinEffectiveDistance { get; set; }
    public double MaxEffectiveDistance { get; set; }

    public override Item Build()
    {
        return new MeleeWeapon(this);
    }

    public override ItemBuilder Copy()
    {
        return new MeleeWeaponBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            BaseDamage = BaseDamage,
            InstantKillChance = InstantKillChance,
            BaseAccuracy = BaseAccuracy,
            EnergyConsumptionModifier = EnergyConsumptionModifier,
            MinEffectiveDistance = MinEffectiveDistance,
            MaxEffectiveDistance = MaxEffectiveDistance
        };
    }
}
