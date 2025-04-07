using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public class RangedWeapon : Weapon
{
    public double NoiseDistance => noiseDistance;

    public RangedWeapon(RangedWeaponBuilder builder) : base(builder)
    {
        noiseDistance = builder.NoiseDistance;
    }

    public override double GetAccuracy(double distance)
    {
        if (distance < 0.5 * MinEffectiveDistance ||
            distance > 1.5 * MaxEffectiveDistance)
        {
            return 0;
        }
        if (distance >= MinEffectiveDistance &&
            distance <= MaxEffectiveDistance)
        {
            return BaseAccuracy;
        }
        if (distance < MinEffectiveDistance)
            return (Math.Exp(distance - 0.5 * MinEffectiveDistance) - 1) *
                   BaseAccuracy / (Math.Exp(0.5 * MinEffectiveDistance) - 1);
        
        return (Math.Exp(1.5 * MaxEffectiveDistance - distance) - 1) *
                   BaseAccuracy / (Math.Exp(0.5 * MaxEffectiveDistance) - 1);
    }

    private readonly double noiseDistance;
}
