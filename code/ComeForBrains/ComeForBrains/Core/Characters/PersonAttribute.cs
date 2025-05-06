namespace ComeForBrains.Core.Characters;

public class PersonAttribute
{
    public double MinValue { get; init; }
    public double MaxValue { get; init; }
    public double Value
    {
        get => attributeValue;
        set => attributeValue = Math.Clamp(value, MinValue, MaxValue);
    }
    public IEnumerable<AttributePenalty> Penalties => penalties;

    public PersonAttribute(
        double minValue,
        double maxValue,
        IEnumerable<AttributePenalty> penalties
    )
    {
        MinValue = minValue;
        MaxValue = maxValue;
        Value = MaxValue;
        this.penalties = new(penalties);
    }
    public PersonAttribute(
        double minValue,
        double maxValue,
        double value,
        IEnumerable<AttributePenalty> penalties
    )
    {
        MinValue = minValue;
        MaxValue = maxValue;
        Value = value;
        this.penalties = new(penalties);
    }

    public double GetPenalty()
    {
        foreach (var penalty in penalties)
            if (Value >= penalty.FromInclusive && Value < penalty.ToExclusive)
                return penalty.Value;
        return 0;
    }

    private double attributeValue;
    private readonly List<AttributePenalty> penalties;
}
