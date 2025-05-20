using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Items;
using ComeForBrains.Exceptions;

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
    public double Physique => CalculateFeature(physique);
    public double DistanceAccuracy => CalculateFeature(distanceAccuracy);
    public double MeleeFight => CalculateFeature(meleeFight);
    public double Speed => CalculateSpeed();

    public double StrengthModifier => CalculateModifier(strength);
    public double DexterityModifier => CalculateModifier(dexterity);
    public double PhysiqueModifier => CalculateModifier(physique);
    public double DistanceAccuracyModifier => CalculateModifier(distanceAccuracy);
    public double MeleeFightModifier => CalculateModifier(meleeFight);
    public double OverloadModifier => CalculateOverloadModifier();

    public double MaxWeight =>
        GameSettings.BaseWeight + 
        GameSettings.StrengthWeightModifier * StrengthModifier;

    public Inventory Inventory { get; init; }

    public bool IsInfected { get; internal set; }
    public double InfectionTime { get; internal set; }

    public IEnumerable<Armor> Armors => armors;
    public Weapon? Weapon => weapon;

    public GameContext GameContext { get; internal set; } = null!;

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
        physique = builder.GetPhysique();
        distanceAccuracy = builder.GetDistanceAccuracy();
        meleeFight = builder.GetMeleeFight();
        speed = builder.GetSpeed();

        Inventory = new Inventory();

        InitializeArmorStructures();
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
    public bool CanEquip(Armor armor)
    {
        foreach(var bodyPart in armor.BodyParts)
        {
            if (armorThiknessByPart[bodyPart] +
                armor.Thikness > GameSettings.MaxArmorThikness)
            {
                return false;
            }
        }
        return true;
    }
    public void Unequip(Armor armor)
    {
        if(armors.Remove(armor))
        {
            foreach(var bodyPart in armor.BodyParts)
            {
                armorValuesByPart[bodyPart] -= armor.ArmorValue;
                armorThiknessByPart[bodyPart] -= armor.Thikness;
            }
            armor.IsEquiped = false;
        }
    }
    public void Unequip(Weapon weapon)
    {
        if(this.weapon is not null)
            this.weapon.IsEquiped = false;
        this.weapon = null;
    }
    public double GetArmorValue(BodyPart bodyPart)
    {
        return armorValuesByPart[bodyPart];
    }
    public double GetArmorThikness(BodyPart bodyPart)
    {
        return armorThiknessByPart[bodyPart];
    }
    public void Equip(Weapon weapon)
    {
        if(this.weapon is not null)
            Unequip(this.weapon);
        this.weapon = weapon;
        weapon.IsEquiped = true;
    }
    public void Equip(Armor armor)
    {
        if(!CanEquip(armor))
            throw new BadEquipException(
                "Can't equip armor: " + armor.ToString() + 
                ". Call CanEquip before equipnemt."
            );
        
        foreach(var bodyPart in armor.BodyParts)
        {
            armorValuesByPart[bodyPart] += armor.ArmorValue;
            armorThiknessByPart[bodyPart] += armor.Thikness;
        }
        armors.Add(armor);
        armor.IsEquiped = true;
    }


    private readonly double strength;
    private readonly double dexterity;
    private readonly double physique;
    private readonly double distanceAccuracy;
    private readonly double meleeFight;
    private readonly double speed;

    private readonly List<Armor> armors = new();
    private readonly Dictionary<BodyPart, double> armorValuesByPart = new();
    private readonly Dictionary<BodyPart, double> armorThiknessByPart = new();

    private Weapon? weapon;

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
        return (CalculateFeature(feature) - GameSettings.FeatureBase) / 2;
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
    private void InitializeArmorStructures()
    {
        foreach(var bodyPart in Enum.GetValues<BodyPart>())
        {
            armorValuesByPart[bodyPart] = GameSettings.ArmorBaseValue;
            armorThiknessByPart[bodyPart] = 0;
        }
    }
}
