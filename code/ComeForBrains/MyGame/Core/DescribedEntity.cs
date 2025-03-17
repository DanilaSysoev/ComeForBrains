using System;

namespace ComeForBrains.Core;

public class DescribedEntity : NamedEntity
{
    public string Description { get => L[description]; }
    
    public DescribedEntity(string name, string description)
        : base(name)
    {
        this.description = description;
    }

    private readonly string description;

    public override string ToString()
    {
        return $"{Name}: {Description}";
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Description);
    }
    public override bool Equals(object? obj)
    {
        return obj is DescribedEntity other &&
               base.Equals(other) &&
               Description == other.Description;
    }
}
