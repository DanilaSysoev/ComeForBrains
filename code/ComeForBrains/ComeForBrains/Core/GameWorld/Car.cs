using ComeForBrains.Core.Building.GameWorld;

namespace ComeForBrains.Core.GameWorld;

public class Car : DescribedEntity
{
    public double TrunkWeightCapacity { get; set; }
    public double TrunkPassabilityCapacity { get; set; }
    public double TankVolume { get; set; }
    public double FuelConsumptionRate { get; set; }
    public double CurrentFuelLevel { get; set; }

    public Car(CarBuilder builder)
        : base(builder.Name, builder.Description)
    {
        TrunkWeightCapacity = builder.TrunkWeightCapacity;
        TrunkPassabilityCapacity = builder.TrunkPassabilityCapacity;
        TankVolume = builder.TankVolume;
        FuelConsumptionRate = builder.FuelConsumptionRate;
        CurrentFuelLevel = builder.CurrentFuelLevel is null ?
                           TankVolume :
                           builder.CurrentFuelLevel.Value;
        if(CurrentFuelLevel > TankVolume)
            CurrentFuelLevel = TankVolume;
    }

    public void Refuel(double volume)
    {
        CurrentFuelLevel += volume;
        if (CurrentFuelLevel > TankVolume)
            CurrentFuelLevel = TankVolume;
    }

    public bool CanMoveOnDistance(double distance)
    {
        return CurrentFuelLevel >= FuelConsumptionRate * distance;
    }

    public void MoveOnDistance(double distance)
    {
        if (!CanMoveOnDistance(distance))
        {
            throw new InvalidOperationException(
                "Not enough fuel to move on this distance"
            );
        }
        CurrentFuelLevel -= FuelConsumptionRate * distance;
    }
}
