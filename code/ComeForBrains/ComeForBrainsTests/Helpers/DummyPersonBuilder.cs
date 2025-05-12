using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Characters;

namespace ComeForBrainsTests.Helpers;

public class DummyPersonBuilder : IPersonBuilder
{
    public double GetBaseInfectionChance()
    {
        return 10;
    }

    public double GetDexterity()
    {
        return 10;
    }

    public double GetDistanceAccuracy()
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

    public double GetMeleeFight()
    {
        return 10;
    }

    public string GetName()
    {
        return "Name";
    }

    public double GetPhysique()
    {
        return 10;
    }

    public PersonAttribute GetSatiety()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }

    public double GetSpeed()
    {
        return 10;
    }

    public double GetStrength()
    {
        return 10;
    }

    public PersonAttribute GetThirst()
    {
        return new PersonAttribute(0, 100, new List<AttributePenalty>());
    }
}
