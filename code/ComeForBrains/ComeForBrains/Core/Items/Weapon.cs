using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public abstract class Weapon : Item
{
    public double BaseDamage => baseDamage;
    public double InstantKillChance => instantKillChance;
    public double BaseAccuracy => baseAccuracy;
    public double EnergyConsumptionModifier => energyConsumptionModifier;
    public double MinEffectiveDistance => minEffectiveDistance;
    public double MaxEffectiveDistance => maxEffectiveDistance;

    protected Weapon(MeleeWeaponBuilder builder)
        : base(builder)
    {
        baseDamage = builder.BaseDamage;
        instantKillChance = builder.InstantKillChance;
        baseAccuracy = builder.BaseAccuracy;
        energyConsumptionModifier = builder.EnergyConsumptionModifier;
        minEffectiveDistance = builder.MinEffectiveDistance;
        maxEffectiveDistance = builder.MaxEffectiveDistance;
    }

    public override void Interact(GameContext context)
    {
        if(!IsEquiped)
        {
            context.Person.Equip(this);
            context.Person.Inventory.RemoveItem(this);
        }
        else
        {
            context.Person.Unequip(this);
            context.Person.Inventory.AddItem(this);
        }
    }

    public override string ToString()
    {
        var res = $"{Name}: {Description}";
        if(IsEquiped)
            return $"[ {res} ]";
        return res;
    }

    public abstract double GetAccuracy(double distance);

    public bool IsEquiped { get; internal set; } = false;

    private readonly double baseDamage;
    private readonly double instantKillChance;
    private readonly double baseAccuracy;
    private readonly double energyConsumptionModifier;
    private readonly double minEffectiveDistance;
    private readonly double maxEffectiveDistance;
}
