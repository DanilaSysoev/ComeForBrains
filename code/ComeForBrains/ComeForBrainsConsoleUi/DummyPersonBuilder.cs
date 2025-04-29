using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Characters;

namespace ComeForBrainsConsoleUi;

public class DummyPersonBuilder : IPersonBuilder
{
    public int GetBaseInfectionChance()
    {
        return 0;
    }

    public int GetDexterity()
    {
        return 0;
    }

    public int GetDistanceAccuracy()
    {
        return 0;
    }

    public PersonAttribute GetEnergy()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }

    public PersonAttribute GetHealth()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }

    public int GetMeleeFight()
    {
        return 0;
    }

    public string GetName()
    {
        return "Dummy";
    }

    public PersonAttribute GetSatiety()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }

    public int GetSpeed()
    {
        return 0;
    }

    public int GetStrength()
    {
        return 0;
    }

    public PersonAttribute GetThirst()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }
}
