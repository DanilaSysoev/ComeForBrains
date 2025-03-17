using System;

namespace ComeForBrains.Core;

public class Tile : NamedEntity
{
    public int PercentOfPassability { get; internal set; } = HundredPercent;
    public string Description
    {
        get => L[description];
        internal set => description = value;
    }
    
    public Tile(string name) : base(name)
    {}
    public Tile() : base(OpenSpaceName)
    {}

    private string description = OpenSpaceDescription;


    internal const string OpenSpaceName = "OpenSpace";
    internal const string OpenSpaceDescription = "OpenSpaceDescription";
    private const int HundredPercent = 100;
}
