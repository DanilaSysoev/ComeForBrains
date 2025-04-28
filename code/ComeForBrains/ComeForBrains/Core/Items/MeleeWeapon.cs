using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public class MeleeWeapon : Weapon
{
    public MeleeWeapon(MeleeWeaponBuilder builder)
        : base(builder)
    {
    }

    public override double GetAccuracy(double distance)
    {
        if (distance > MaxEffectiveDistance || distance < MinEffectiveDistance)
            return 0;
        return BaseAccuracy;
    }
}
