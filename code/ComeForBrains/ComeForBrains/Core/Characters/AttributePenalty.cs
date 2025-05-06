namespace ComeForBrains.Core.Characters;

public class AttributePenalty
{
    public AttributePenalty(
        double fromInclusive, double toExclusive, double value
    )
    {
        FromInclusive = fromInclusive;
        ToExclusive = toExclusive;
        Value = value;
    }

    public double FromInclusive { get; set; }
    public double ToExclusive { get; set; }
    public double Value { get; set; }
}
