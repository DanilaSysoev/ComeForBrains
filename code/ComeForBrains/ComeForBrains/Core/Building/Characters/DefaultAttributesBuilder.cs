using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building.Characters;

public class DefaultAttributesBuilder : IPersonBuilder
{
    public DefaultAttributesBuilder(
        string personName,
        double strength,
        double dexterity,
        double physique,
        double distanceAccuracy,
        double meleeFight,
        double speed = DefaultSpeed
    )
    {
        this.personName = personName;
        this.strength = strength;
        this.dexterity = dexterity;
        this.physique = physique;
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
    public double GetBaseInfectionChance()
    {
        return 25;
    }
    public double GetStrength()
    {
        return strength;
    }
    public double GetDexterity()
    {
        return dexterity;
    }
    public double GetPhysique()
    {
        return physique;
    }
    public double GetDistanceAccuracy()
    {
        return distanceAccuracy;
    }
    public double GetMeleeFight()
    {
        return meleeFight;
    }
    public double GetSpeed()
    {
        return speed;
    }

    private static PersonAttribute CreateAttribute(double low, double mid, double high)
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
    private readonly double strength;
    private readonly double dexterity;
    private readonly double physique;
    private readonly double distanceAccuracy;
    private readonly double meleeFight;
    private readonly double speed;
    
    private const double MinValue = 0;
    private const double MaxValue = 100;

    private const double LowPenalty = 0.2;
    private const double MidPenalty = 0.5;
    private const double HighPenalty = 0.8;

    private const double DefaultSpeed = 100;
}
