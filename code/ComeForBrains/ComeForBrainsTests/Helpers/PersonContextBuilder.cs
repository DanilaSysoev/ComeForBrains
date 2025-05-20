using ComeForBrains.Core;
using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrainsTests.Helpers;

public class PersonContextBuilder : IGameContextBuilder
{
    public PersonContextBuilder(Person person)
    {
        this.person = person;
    }

    public Camp BuildCamp()
    {
        return new Camp(new DummyCampBuilder());
    }

    public Person BuildPerson()
    {
        return person;
    }

    public Car BuildCar()
    {
        return new Car(new CarBuilder());
    }

    private readonly Person person;

    public uint DayNumber { get; set; }

    public DayStage DayStage { get; set; }
}
