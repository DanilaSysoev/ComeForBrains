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

    public override void Interact(GameContext context)
    {
        context.Person.Satiety.Value += SatietyPower;
        context.Person.Thirst.Value += ThirstPower;
        context.Person.Energy.Value += EnergyPower;

        context.Person.Inventory.RemoveItem(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is Provision provision &&
               base.Equals(obj) &&
               Math.Abs(SatietyPower - provision.SatietyPower) < 0.000001 &&
               Math.Abs(ThirstPower - provision.ThirstPower) < 0.000001 &&
               Math.Abs(EnergyPower - provision.EnergyPower) < 0.000001;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(), ThirstPower, SatietyPower, EnergyPower
        );
    }
}
