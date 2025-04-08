using System;
using ComeForBrains.Core;
using ComeForBrains.Core.Building.Mechanics.Base;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrainsTests.Helpers;

public class DummyDamageDistributorBuilder : ICampDamageDistributorBuilder
{
    public ICampDamageDistributor Build(GameContext gameContext, double totalDamage)
    {
        return new DummyDamageDistributor(gameContext, totalDamage);
    }
}
