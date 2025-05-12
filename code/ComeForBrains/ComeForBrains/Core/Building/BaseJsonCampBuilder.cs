using System.Text.Json;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Mechanics;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.Building;

public class BaseJsonCampBuilder : ICampBuilder
{
    public BaseJsonCampBuilder(IJsonProvider jsonProvider)
    {
        var descriptor = 
            JsonSerializer.Deserialize<CampBuilderDescriptor>(
                jsonProvider.GetJson()
            )!;
        baseDamage = descriptor.baseDamage;
        dailyDamageIncrease = descriptor.dailyDamageIncrease;
    }

    public ICampDestructor BuildDestructor()
    {
        return new DailyLinearlyIncreasingCampDestructor(
            new RandomExternalPrioritizedCampDamageDistributorBuilder(),
            baseDamage,
            dailyDamageIncrease
        );
    }

    private readonly double baseDamage;
    private readonly double dailyDamageIncrease;

    private sealed class CampBuilderDescriptor
    {
        public double baseDamage { get; set; } = 0;
        public double dailyDamageIncrease { get; set; } = 0;
    }
}
