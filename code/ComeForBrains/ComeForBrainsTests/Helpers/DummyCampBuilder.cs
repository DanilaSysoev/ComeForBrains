using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrainsTests.Helpers;

public class DummyCampBuilder : ICampBuilder
{
    public ICampDestructor BuildDestructor()
    {
        return new DailyLinearlyIncreasingCampDestructor(
            new DummyDamageDistributorBuilder(),
            10,
            5
        );
    }
}
