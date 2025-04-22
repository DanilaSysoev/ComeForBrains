using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class CampElementBuilder : ItemBuilder
{
    public double FortificationValue { get; set; }
    public double ComfortValue { get; set; }
    public CampElementType ElementType =>
        Enum.Parse<CampElementType>(ElementTypeName);
    public double MaxStrength { get; set; }
    public double Strength { get; set; }
    public string ElementTypeName { get; set; } = "External";

    public override Item Build()
    {
        return new CampElement(this);
    }
}
