using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public class Provision : Item
{
    public double SatietyPower { get; init; }
    public double ThirstPower { get; init; }
    public double EnergyPower { get; init; }

    public Provision(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        double satietyPower,
        double thirstPower,
        double energyPower
    ) : base(name, description, weight, passabilityPenalty)
    {
        SatietyPower = satietyPower;
        ThirstPower = thirstPower;
        EnergyPower = energyPower;
    }

    public Provision(ProvisionBuilder builder)
        : base(builder)
    {
        SatietyPower = builder.SatietyPower;
        ThirstPower = builder.ThirstPower;
        EnergyPower = builder.EnergyPower;
    }

    public override void Interact(GameContext context)
    {
        context.Person.Satiety.Value += SatietyPower;
        context.Person.Thirst.Value += ThirstPower;
        context.Person.Energy.Value += EnergyPower;

        context.Person.Inventory.RemoveItem(this);
    }
}
