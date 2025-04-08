using ComeForBrains.Core;
using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrainsTests.Helpers;

public class DummyCampDestructor : ICampDestructor
{
    public void DamageCamp(GameContext gameContext)
    {
    }

    public IEnumerable<CampElement> GetLastDamagedElements()
    {
        return new List<CampElement>();
    }
}
