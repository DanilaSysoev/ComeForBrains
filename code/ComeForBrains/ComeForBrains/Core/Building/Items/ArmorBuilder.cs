using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building.Items;

public class ArmorBuilder : ItemBuilder
{
    public IEnumerable<BodyPart> BodyParts { get; set; }
        = new List<BodyPart>();
    public double Thikness { get; set; }
    public double InfectionModifier { get; set; }
    public double ArmorValue { get; set; }
    public double EnergyConsumptionModifier { get; set; }
}
