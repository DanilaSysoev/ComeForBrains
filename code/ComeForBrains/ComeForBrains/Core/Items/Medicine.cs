using ComeForBrains.Core.Building.Items;

namespace ComeForBrains.Core.Items;

public class Medicine : Item
{
    public double HealingPower { get; init; }
    public int Count { get; private set; }

    public Medicine(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        double healingPower,
        int count = DefaultCount
    ) : base(name, description, weight, passabilityPenalty)
    {
        HealingPower = healingPower;
        Count = count;
    }

    public Medicine(
        string name,
        string description,
        double weight,
        double healingPower,
        int count = DefaultCount
    ) : base(name, description, weight, DefaultPassabilityPenalty)
    {
        HealingPower = healingPower;
        Count = count;
    }

    public Medicine(MedicineBuilder builder)
        : base(builder)
    {
        HealingPower = builder.HealingPower;
        Count = builder.Count;
    }

    public override void Interact(GameContext context)
    {
        if(Count > 0)
        {
            context.Person.Health.Value += HealingPower;
            Count--;
        }
        if(Count == 0)
        {
            context.Camp.RemoveFromStorage(this);
            context.Person.Inventory.RemoveItem(this);
        }
    }

    public const double DefaultPassabilityPenalty = 0.0002;
    public const int DefaultCount = 1;
}
