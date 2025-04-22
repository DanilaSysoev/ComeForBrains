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
}
