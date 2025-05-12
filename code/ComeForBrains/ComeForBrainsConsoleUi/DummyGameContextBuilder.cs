using ComeForBrains.Core;
using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsConsoleUi;

public class DummyGameContextBuilder : IGameContextBuilder
{
    public uint DayNumber => 0;

    public DayStage DayStage => DayStage.Day;

    public Camp BuildCamp()
    {
        return new Camp(new DummyCampBuilder());
    }

    public Person BuildPerson()
    {
        return new Person(new DummyPersonBuilder());
    }
}
