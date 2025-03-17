namespace ComeForBrains.Core;

public class NamedEntity : GameEntity
{
    public string Name { get => L[name]; }

    public NamedEntity(string name) : base()
    {
        this.name = name;
    }
    
    public override string ToString()
    {
        return Name;
    }
    public override bool Equals(object? obj)
    {
        return obj is NamedEntity ne &&
               ne.name == name;
    }
    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    private readonly string name;
}
