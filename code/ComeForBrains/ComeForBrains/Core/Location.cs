namespace ComeForBrains.Core;

public class Location : NamedEntity
{
    public Settlement Settlement
    {
        get => settlement;
        internal set => settlement = value;
    }

    public Location(string name) : base(name)
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is Location location &&
                location.Name == Name &&
                location.Settlement == Settlement;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Settlement.Name);
    }

    private Settlement settlement = null!;
}
