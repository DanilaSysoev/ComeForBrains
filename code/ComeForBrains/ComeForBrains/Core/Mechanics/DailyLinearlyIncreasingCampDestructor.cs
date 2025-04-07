using ComeForBrains.Core.Building.Mechanics;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.Mechanics;

public class DailyLinearlyIncreasingCampDestructor : ICampDestructor
{
    public ICampDamageDistributorBuilder DamageDistributorBuilder { get; set; }

    public double BaseDamage { get; init; }
    public double DailyDamageIncrease { get; init; }

    public void DamageCamp(GameContext gameContext)
    {
        var damageDistributor =
            DamageDistributorBuilder.Build(
                gameContext,
                BaseDamage + DailyDamageIncrease * gameContext.DayNumber
            );
        foreach(var campElement in gameContext.Camp.CampElements)
        {
            var damage = damageDistributor.CalculateDamage(campElement);
            campElement.Damage(damage);
        }
    }

    public DailyLinearlyIncreasingCampDestructor(
        ICampDamageDistributorBuilder damageDistributorBuilder,
        double baseDamage,
        double dailyDamageIncrease
    )
    {
        DamageDistributorBuilder = damageDistributorBuilder;
        BaseDamage = baseDamage;
        DailyDamageIncrease = dailyDamageIncrease;
    }
}
