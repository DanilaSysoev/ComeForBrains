using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building;

public class GameContextBuilder : IGameContextBuilder
{
    public GameContextBuilder(
        IPersonBuilder personBuilder,
        ICampBuilder campBuilder,
        uint dayNumber
    )
    {
        DayNumber = dayNumber;
        this.personBuilder = personBuilder;
        this.campBuilder = campBuilder;
    }

    public uint DayNumber { get; set; }

    public Camp BuildCamp()
    {
        return new Camp(campBuilder);
    }

    public Person BuildPerson()
    {
        return new Person(personBuilder);
    }

    private readonly IPersonBuilder personBuilder;
    private readonly ICampBuilder campBuilder;
}
