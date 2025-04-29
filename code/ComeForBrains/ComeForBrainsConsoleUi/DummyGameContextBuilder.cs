using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsConsoleUi;

public class DummyGameContextBuilder : IGameContextBuilder
{
    public uint DayNumber => 0;

    public Camp BuildCamp()
    {
        return new Camp(new DummyCampBuilder());
    }

    public Person BuildPerson()
    {
        return new Person(new DummyPersonBuilder());
    }
}
