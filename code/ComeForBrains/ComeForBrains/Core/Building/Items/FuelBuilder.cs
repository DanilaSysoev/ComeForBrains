using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class FuelBuilder : ItemBuilder
{
    public double Volume { get; set; }

    public override Item Build()
    {
        return new Fuel(this);
    }

    public override ItemBuilder Copy()
    {
        return new FuelBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            Volume = Volume
        };
    }
}
