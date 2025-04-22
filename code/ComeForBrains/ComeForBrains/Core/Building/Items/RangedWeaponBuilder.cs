using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class RangedWeaponBuilder : WeaponBuilder
{
    public double NoiseDistance { get; set; }

    public override Item Build()
    {
        return new RangedWeapon(this);
    }
}
