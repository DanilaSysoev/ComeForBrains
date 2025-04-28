using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class ContainerBuilder : ItemBuilder
{
    public override Item Build()
    {
        return new Container(this);
    }

    public override ItemBuilder Copy()
    {
        return new ContainerBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty
        };
    }
}
