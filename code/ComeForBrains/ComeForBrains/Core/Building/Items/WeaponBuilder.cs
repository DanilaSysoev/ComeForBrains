using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class WeaponBuilder : ItemBuilder
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
}
