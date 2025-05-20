namespace ComeForBrains.Core.Building.GameWorld;

public class CarBuilder
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public double TrunkWeightCapacity { get; set; }
    public double TrunkPassabilityCapacity { get; set; }
    public double TankVolume { get; set; }
    public double FuelConsumptionRate { get; set; }
    public double? CurrentFuelLevel { get; set; }
}
