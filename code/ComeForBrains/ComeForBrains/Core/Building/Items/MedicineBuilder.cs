using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class MedicineBuilder : ItemBuilder
{
    public double HealingPower { get; set; }
    public int Count { get; set; }

    public override Item Build()
    {
        return new Medicine(this);
    }

    public override ItemBuilder Copy()
    {
        return new MedicineBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            HealingPower = HealingPower,
            Count = Count
        };
    }
}
