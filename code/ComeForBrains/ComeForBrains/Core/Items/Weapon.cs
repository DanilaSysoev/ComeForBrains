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
        if(!isEquiped)
        {
            context.Person.Equip(this);
            context.Person.Inventory.RemoveItem(this);
            isEquiped = true;
        }
        else
        {
            context.Person.Unequip(this);
            context.Person.Inventory.AddItem(this);
            isEquiped = false;
        }
    }

    public abstract double GetAccuracy(double distance);

    private bool isEquiped = false;

    private readonly double baseDamage;
    private readonly double instantKillChance;
    private readonly double baseAccuracy;
    private readonly double energyConsumptionModifier;
    private readonly double minEffectiveDistance;
    private readonly double maxEffectiveDistance;
}
