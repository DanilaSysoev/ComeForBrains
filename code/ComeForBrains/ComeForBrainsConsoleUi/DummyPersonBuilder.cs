using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Characters;

namespace ComeForBrainsConsoleUi;

public class DummyPersonBuilder : IPersonBuilder
{
    public double GetBaseInfectionChance()
    {
        return 0;
    }

    public double GetDexterity()
    {
        return 0;
    }

    public double GetDistanceAccuracy()
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

    public double GetMeleeFight()
    {
        return 0;
    }

    public string GetName()
    {
        return "Dummy";
    }

    public double GetPhysique()
    {
        return 0;
    }

    public PersonAttribute GetSatiety()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }

    public double GetSpeed()
    {
        return 0;
    }

    public double GetStrength()
    {
        return 0;
    }

    public PersonAttribute GetThirst()
    {
        return new PersonAttribute(0, 0, new List<AttributePenalty>());
    }
}
