using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.Items;

public class CampElementBuilder : ItemBuilder
{
    public double FortificationValue { get; set; }
    public double ComfortValue { get; set; }
    public CampElementType ElementType { get; set; }
    public double MaxSrength { get; set; }
    public double Srength { get; set; }
}
