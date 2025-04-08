using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building;

public interface IGameContextBuilder
{
    Person BuildPerson();
    Camp BuildCamp();

    uint DayNumber { get; }
}
