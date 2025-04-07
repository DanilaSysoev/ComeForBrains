using ComeForBrains.Core.Building.Items;
using ComeForBrains.Service;

namespace ComeForBrains.Core.Items;

public abstract class Item : DescribedEntity
{
    public ulong Id { get; init; }

    public virtual double Weight { get => weight; }
    public double PassabilityPenalty { get; init; }

    public Container? Container { get; internal set; }
    public bool Stored => Container is not null;

    protected Item(
        string name,
        string description,
        double weight,
        double passabilityPenalty
    ) : base(name, description)
    {
        Id = IdProvider.NextId();
        this.weight = weight;

        PassabilityPenalty = passabilityPenalty;
    }

    protected Item(ItemBuilder builder)
        : base(builder.Name, builder.Description)
    {
        Id = IdProvider.NextId();
        weight = builder.Weight;
        PassabilityPenalty = builder.PassabilityPenalty;
    }

    public abstract void Interact(GameContext context);

    public override bool Equals(object? obj)
    {
        return obj is Item item &&
               Id == item.Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    private readonly double weight;
}
