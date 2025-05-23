using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class RangedWeaponBuilder : MeleeWeaponBuilder
{
    public double NoiseDistance { get; set; }

    public override Item Build()
    {
        return new RangedWeapon(this);
    }

    public override ItemBuilder Copy()
    {
        return new RangedWeaponBuilder()
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
            MaxEffectiveDistance = MaxEffectiveDistance,
            NoiseDistance = NoiseDistance
        };
    }
}
