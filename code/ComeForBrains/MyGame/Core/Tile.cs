using System;

namespace ComeForBrains.Core;

public class Tile : DescribedEntity
{
    public int PercentOfPassability { get; internal set; } = HundredPercent;
    
    public Tile(string name, string description) : base(name, description)
    {}

    private const int HundredPercent = 100;
}
