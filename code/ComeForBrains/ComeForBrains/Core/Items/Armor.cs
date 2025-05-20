using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Items;

public class Armor : Item
{
    public IEnumerable<BodyPart> BodyParts => bodyParts;
    public double Thikness => thikness;
    public double InfectionModifier => infectionModifier;
    public double ArmorValue => armorValue;
    public double EnergyConsumptionModifier => energyConsumptionModifier;

    public bool IsEquiped { get; internal set; }

    public Armor(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        IEnumerable<BodyPart> bodyParts,
        double thikness,
        double infectionModifier,
        double armorValue,
        double energyConsumptionModifier
    ) : base(name, description, weight, passabilityPenalty)
    {
        this.bodyParts = bodyParts.ToList();
        this.thikness = thikness;
        this.infectionModifier = infectionModifier;
        this.armorValue = armorValue;
        this.energyConsumptionModifier = energyConsumptionModifier;
    }
    public Armor(ArmorBuilder builder)
        : base(builder)
    {
        bodyParts = builder.BodyParts.ToList();
        thikness = builder.Thikness;
        infectionModifier = builder.InfectionModifier;
        armorValue = builder.ArmorValue;
        energyConsumptionModifier = builder.EnergyConsumptionModifier;
    }

    public override void Interact(GameContext context)
    {
        if(!IsEquiped && context.Person.CanEquip(this))
        {
            context.Person.Equip(this);
            context.Person.Inventory.RemoveItem(this);
        }
        else if(IsEquiped)
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


    private readonly List<BodyPart> bodyParts;
    private readonly double thikness;
    private readonly double infectionModifier;
    private readonly double armorValue;
    private readonly double energyConsumptionModifier;
}