using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public interface ICampDamageDistributorBuilder
{
    ICampDamageDistributor Build(GameContext gameContext, double totalDamage);
}
