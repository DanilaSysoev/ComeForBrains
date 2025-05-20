using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public class Fuel : Item
{
    public override double Weight => 
        EmptyWeight + GameSettings.GasolineDencity * Volume * 1000;

    public double EmptyWeight { get; internal set; }
    public double Volume { get; internal set; }

    public Fuel(FuelBuilder builder) : base(builder)
    {
        EmptyWeight = builder.Weight;
        Volume = builder.Volume;
    }

    public override void Interact(GameContext context)
    {
        var maxRefuel = CalcMaxRefuel(context);
        context.Car.Refuel(maxRefuel);
        Volume -= maxRefuel;
        if(Math.Abs(Volume) <= 0.000001)
        {
            context.Camp.RemoveFromStorage(this);
            context.Person.Inventory.RemoveItem(this);
        }
    }

    public double CalcMaxRefuel(GameContext context)
    {
        return Math.Min(
            context.Car.TankEmptySpace,
            Volume
        );
    }
}
