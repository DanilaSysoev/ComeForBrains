namespace ComeForBrains.Core.Characters;

public class AttributePenalty
{
    public AttributePenalty(
        int fromInclusive, int toExclusive, double value
    )
    {
        FromInclusive = fromInclusive;
        ToExclusive = toExclusive;
        Value = value;
    }

    public int FromInclusive { get; init; }
    public int ToExclusive { get; init; }
    public double Value { get; init; }
}
