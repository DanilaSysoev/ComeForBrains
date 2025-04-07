using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.Building.GameWorld;

public interface ICampBuilder
{
    ICampDestructor BuildDestructor();
}
