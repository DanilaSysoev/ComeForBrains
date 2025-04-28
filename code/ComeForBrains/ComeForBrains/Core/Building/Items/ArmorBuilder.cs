using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class ArmorBuilder : ItemBuilder
{
    public IEnumerable<BodyPart> BodyParts => GetBodyParts();
    public double Thikness { get; set; }
    public double InfectionModifier { get; set; }
    public double ArmorValue { get; set; }
    public double EnergyConsumptionModifier { get; set; }
    public List<string> BodyPartNames { get; set; } = null!;

    public override Item Build()
    {
        return new Armor(this);
    }

    public override ItemBuilder Copy()
    {
        return new ArmorBuilder()
        {
            Name = Name,
            Description = Description,
            Weight = Weight,
            PassabilityPenalty = PassabilityPenalty,
            Thikness = Thikness,
            InfectionModifier = InfectionModifier,
            ArmorValue = ArmorValue,
            EnergyConsumptionModifier = EnergyConsumptionModifier,
            BodyPartNames = BodyPartNames
        };
    }

    private List<BodyPart> GetBodyParts()
    {
        if (bodyParts is null)            
            bodyParts = BodyPartNames
                            .Select(bp => Enum.Parse<BodyPart>(bp))
                            .ToList();
        return bodyParts;
    }
    private List<BodyPart>? bodyParts;
}
