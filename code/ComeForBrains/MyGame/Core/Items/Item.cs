namespace ComeForBrains.Core.Items;

public abstract class Item : DescribedEntity
{
    public virtual int Weight { get => weight; }
    public int PassabilityPenalty { get; init; }

    public Container? Container { get; internal set; }
    public bool Stored => Container is not null;

    protected Item(
        string name,
        string description,
        int weight,
        int passabilityPenalty
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
               weight == item.weight &&
               PassabilityPenalty == item.PassabilityPenalty;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(),
                                weight,
                                PassabilityPenalty);
    }

    private readonly int weight;
}
