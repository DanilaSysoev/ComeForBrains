using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;

namespace ComeForBrainsTests.Helpers;

public class DummyPersonBuilder : IPersonBuilder
{
    public int GetBaseInfectionChance()
    {
        return 10;
    }

    public int GetDexterity()
    {
        return 10;
    }

    public int GetDistanceAccuracy()
    {
        return 10;
    }

    public PersonAttribute GetEnergy()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }

    public PersonAttribute GetHealth()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }

    public int GetMeleeFight()
    {
        return 10;
    }

    public string GetName()
    {
        return "Name";
    }

    public PersonAttribute GetSatiety()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }

    public int GetSpeed()
    {
        return 10;
    }

    public int GetStrength()
    {
        return 10;
    }

    public PersonAttribute GetThirst()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }
}
