namespace ComeForBrains.Core.Building.Mechanics.Base;

public interface IEnvironmentModifier
{
    public string Description { get; }

    public void Apply();
    public void Undo();
}
