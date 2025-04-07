using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public enum CampElementType
{
    Internal,
    External
}

public class CampElement : Item
{
    public double BaseFortification => baseFortification;
    public double BaseComfort => baseComfort;

    public double Fortification => baseFortification * Condition;
    public double Comfort => baseComfort * Condition;

    public double MaxStrength => maxStrength;
    public double Strength => strength;

    public double Condition => Strength / MaxStrength;
    
    public CampElementType ElementType => elementType;

    public CampElement(CampElementBuilder builder)
        : base(builder)
    {
        baseFortification = builder.FortificationValue;
        baseComfort = builder.ComfortValue;
        maxStrength = builder.MaxSrength;
        strength = builder.Srength;
        elementType = builder.ElementType;
    }

    public override void Interact(GameContext context)
    {
        if(context.PersonInCamp)
        {
            context.Camp.SetupCampElement(this);
            context.Camp.RemoveFromStorage(this);
            context.Person.Inventory.RemoveItem(this);
        }
    }

    public void Damage(double damage)
    {
        strength -= damage;
        if (strength <= 0)
            strength = 0;
    }

    private double strength;

    private readonly double maxStrength;
    private readonly double baseFortification;
    private readonly double baseComfort;
    private readonly CampElementType elementType;
}
