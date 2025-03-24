using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core;

public class GameContext
{
    public Person Person { get; init; }

    public GameContext(Person person)
    {
        Person = person;
    }
}
