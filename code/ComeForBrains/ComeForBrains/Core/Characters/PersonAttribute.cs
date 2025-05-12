namespace ComeForBrains.Core.Characters;

public class PersonAttribute
{
    public double MinValue
    {
        get => minValue;
        set
        {
            minValue = value;
            if (minValue > MaxValue)
                minValue = MaxValue;
            if (Value < minValue)
                Value = minValue;
        }
    }
    public double MaxValue
    {
        get => maxValue;
        set
        {
            maxValue = value;
            if (MinValue > maxValue)
                maxValue = MinValue;
            if (Value > maxValue)
                Value = maxValue;
        }
    }
    public double Value
    {
        get => value;
        set => this.value = Math.Clamp(value, MinValue, MaxValue);
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

    private double value;
    private double minValue;
    private double maxValue;
    private readonly List<AttributePenalty> penalties;
}
