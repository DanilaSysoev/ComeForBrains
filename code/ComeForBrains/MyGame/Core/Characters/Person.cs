using ComeForBrains.Core.Building;

namespace ComeForBrains.Core.Characters;

public class Person
{
    public string Name { get; init; }
    public PersonAttribute Satiety { get; init; }
    public PersonAttribute Energy { get; init; }
    public PersonAttribute Health { get; init; }
    public PersonAttribute Thirst { get; init; }

    public double BaseInfectionChanse { get; init; }

    public double Strength => CalculateFeature(strength);
    public double Dexterity => CalculateFeature(dexterity);
    public double DistanceAccuracy => CalculateFeature(distanceAccuracy);
    public double MeleeFight => CalculateFeature(meleeFight);
    public double Speed => CalculateSpeed();

    public double StrengthModifier => CalculateModifier(strength);
    public double DexterityModifier => CalculateModifier(dexterity);
    public double DistanceAccuracyModifier => CalculateModifier(distanceAccuracy);
    public double MeleeFightModifier => CalculateModifier(meleeFight);
    public double OverloadModifier => CalculateOverloadModifier();

    public double MaxWeight => BaseWeight + 5 * StrengthModifier;

    public Inventory Inventory { get; init; }

    public bool IsInfected { get; internal set; }
    public double InfectionTime { get; internal set; }

    public Person(IPersonBuilder builder)
    {   
        Name = builder.GetName();
        Satiety = builder.GetSatiety();
        Energy = builder.GetEnergy();
        Health = builder.GetHealth();
        Thirst = builder.GetThirst();
        BaseInfectionChanse = builder.GetBaseInfectionChance();

        strength = builder.GetStrength();
        dexterity = builder.GetDexterity();
        distanceAccuracy = builder.GetDistanceAccuracy();
        meleeFight = builder.GetMeleeFight();
        speed = builder.GetSpeed();

        Inventory = new Inventory();
    }

    public void KillInfection()
    {
        IsInfected = false;
        InfectionTime = 0;
    }
    public void Infect()
    {
        if(!IsInfected)
        {
            InfectionTime = 0;
            IsInfected = true;
        }
    }
    public void TimePassed(double deltaTime)
    {
        if(IsInfected)
            InfectionTime += deltaTime;
    }


    private readonly double strength;
    private readonly double dexterity;
    private readonly double distanceAccuracy;
    private readonly double meleeFight;
    private readonly double speed;


    private double CalculateFeature(double feature)
    {
        return feature
             * (1.0 - Satiety.GetPenalty())
             * (1.0 - Energy.GetPenalty())
             * (1.0 - Thirst.GetPenalty())
             * (1.0 - Health.GetPenalty());
    }
    private double CalculateModifier(double feature)
    {
        return (CalculateFeature(feature) - FeatureBase) / 2;
    }
    private double CalculateSpeed()
    {
        double baseValue = speed + DexterityModifier * 10 - OverloadModifier * 20;
        return CalculateFeature(baseValue);
    }
    private double CalculateOverloadModifier()
    {
        if(Inventory.Weight <= MaxWeight)
            return 0;
        return (Inventory.Weight - MaxWeight) / 10 + 1;
    }

    private const long FeatureBase = 10;
    private const long BaseWeight = 50;
}
