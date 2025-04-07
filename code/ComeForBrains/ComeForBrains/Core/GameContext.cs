using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core;

public class GameContext
{
    public Person Person { get; init; }
    public Camp Camp { get; init; }
    public uint DayNumber { get; private set; }

    public bool PersonInCamp { get; private set; } = true;

    public GameContext(IGameContextBuilder builder)
    {
        Person = builder.BuildPerson();
        Camp = builder.BuildCamp();
        DayNumber = 0;

        Person.GameContext = this;
        Camp.GameContext = this;
    }

    public void GoToNextDay()
    {
        EndOfDayOperaions();
        ++DayNumber;
    }

    public void MoveToCamp()
    {
        PersonInCamp = true;
    }


    private void EndOfDayOperaions()
    {
        System.Console.BackgroundColor = ConsoleColor.Red;
        System.Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("You need implement method EndOfDayOparations");
        System.Console.ResetColor();
    }
}
