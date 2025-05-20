using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.Mechanics;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core;

public enum DayStage
{
    Day,
    Night
}

public class GameContext
{
    public Person Person { get; init; }
    public Camp Camp { get; init; }
    public uint DayNumber { get; internal set; }
    public DayStage DayStage { get; internal set; }
    public Car Car { get; internal set; }

    public bool PersonInCamp { get; private set; } = true;

    public bool IsGameEnded { get; set; }

    public DayStageSwitcher DayStageSwitcher { get; private set; }
    public SleepProcessor SleepProcessor { get; private set; }
    public GameEndChecker GameEndChecker { get; private set; }

    public GameContext(IGameContextBuilder builder)
    {
        Person = builder.BuildPerson();
        Camp = builder.BuildCamp();
        Car = builder.BuildCar();
        DayNumber = builder.DayNumber;
        DayStage = builder.DayStage;

        Person.GameContext = this;
        Camp.GameContext = this;

        DayStageSwitcher = new DayStageSwitcher(this);
        SleepProcessor = new SleepProcessor(this);
        GameEndChecker = new GameEndChecker(this);
    }

    public void MovePersonToCamp()
    {
        PersonInCamp = true;
    }
}
