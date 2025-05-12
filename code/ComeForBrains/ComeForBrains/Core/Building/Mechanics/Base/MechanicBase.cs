namespace ComeForBrains.Core.Building.Mechanics.Base;

public class MechanicBase
{
    protected MechanicBase(GameContext context)
    {
        Context = context;
    }

    public GameContext Context { get; private set; }
}
