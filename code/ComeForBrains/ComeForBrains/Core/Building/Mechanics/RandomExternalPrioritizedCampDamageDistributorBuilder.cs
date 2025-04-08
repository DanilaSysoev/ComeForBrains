using ComeForBrains.Core.Building.Mechanics.Base;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public class RandomExternalPrioritizedCampDamageDistributorBuilder
    : ICampDamageDistributorBuilder
{
    public ICampDamageDistributor Build(
        GameContext gameContext, double totalDamage
    )
    {
        return new RandomExternalPrioritizedCampDamageDistributor(
            gameContext, totalDamage
        );
    }
}
