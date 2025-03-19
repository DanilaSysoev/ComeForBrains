namespace ComeForBrains.Core.Items;

public abstract class Item : DescribedEntity
{
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
        this.weight = weight;

        PassabilityPenalty = passabilityPenalty;
    }

    public abstract void Interact(GameContext context);

    public override bool Equals(object? obj)
    {
        return obj is Item item &&
               base.Equals(obj) &&
               Math.Abs(weight -
                        item.weight) < 0.0000001 &&
               Math.Abs(PassabilityPenalty -
                        item.PassabilityPenalty) < 0.0000001;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(),
                                weight,
                                PassabilityPenalty);
    }

    private readonly double weight;
}
