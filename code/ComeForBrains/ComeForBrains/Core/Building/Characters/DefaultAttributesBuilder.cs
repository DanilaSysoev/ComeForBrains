using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building.Characters;

public class DefaultAttributesBuilder : IPersonBuilder
{
    public DefaultAttributesBuilder(
        string personName,
        int strength,
        int dexterity,
        int distanceAccuracy,
        int meleeFight,
        int speed = DefaultSpeed
    )
    {
        this.personName = personName;
        this.strength = strength;
        this.dexterity = dexterity;
        this.distanceAccuracy = distanceAccuracy;
        this.meleeFight = meleeFight;
        this.speed = speed;
    }

    public string GetName()
    {
        return personName;
    }
    public PersonAttribute GetEnergy()
    {
        return CreateAttribute(30, 50, 80);
    }
    public PersonAttribute GetHealth()
    {
        return CreateAttribute(30, 50, 80);
    }
    public PersonAttribute GetSatiety()
    {
        return CreateAttribute(20, 40, 60);
    }
    public PersonAttribute GetThirst()
    {
        return CreateAttribute(20, 40, 60);
    }
    public int GetBaseInfectionChance()
    {
        return 25;
    }
    public int GetStrength()
    {
        return strength;
    }
    public int GetDexterity()
    {
        return dexterity;
    }
    public int GetDistanceAccuracy()
    {
        return distanceAccuracy;
    }
    public int GetMeleeFight()
    {
        return meleeFight;
    }
    public int GetSpeed()
    {
        return speed;
    }

    private static PersonAttribute CreateAttribute(int low, int mid, int high)
    {
        return new PersonAttribute(
            MinValue,
            MaxValue,
            new List<AttributePenalty> {
                new AttributePenalty (mid, high, LowPenalty),
                new AttributePenalty (low, mid, MidPenalty),
                new AttributePenalty (MinValue, low, HighPenalty)
            }
        );
    }

    private readonly string personName;
    private readonly int strength;
    private readonly int dexterity;
    private readonly int distanceAccuracy;
    private readonly int meleeFight;
    private readonly int speed;
    
    private const int MinValue = 0;
    private const int MaxValue = 100;

    private const double LowPenalty = 0.2;
    private const double MidPenalty = 0.5;
    private const double HighPenalty = 0.8;

    private const int DefaultSpeed = 100;
}
