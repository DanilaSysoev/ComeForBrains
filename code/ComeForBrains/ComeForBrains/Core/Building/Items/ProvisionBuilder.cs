using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class ProvisionBuilder : ItemBuilder
{
    public double SatietyPower { get; set; }
    public double ThirstPower { get; set; }
    public double EnergyPower { get; set; }

    public override Item Build()
    {
        return new Provision(this);
    }

    public override ItemBuilder Copy()
    {
        return new ProvisionBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            SatietyPower = SatietyPower,
            ThirstPower = ThirstPower,
            EnergyPower = EnergyPower
        };
    }
}
