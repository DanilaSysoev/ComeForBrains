using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Mechanics;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrainsConsoleUi;

public class DummyCampBuilder : ICampBuilder
{
    public ICampDestructor BuildDestructor()
    {
        return new DummyCampDestructor();
    }
}
