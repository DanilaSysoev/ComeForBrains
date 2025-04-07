namespace ComeForBrains.Core.Building.Items;

public class ItemBuilder
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Weight { get; set; }
    public double PassabilityPenalty { get; set; }
}
