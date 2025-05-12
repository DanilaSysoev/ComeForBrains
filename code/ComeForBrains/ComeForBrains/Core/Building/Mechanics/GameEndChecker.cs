using ComeForBrains.Core.Building.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public class GameEndChecker : MechanicBase
{
    public GameEndChecker(GameContext context)
        : base(context)
    {
    }

    public bool IsGameEnded()
    {
        return Context.Person.Health.Value <= 0 ||
               Context.Person.Satiety.Value <= 0 ||
               Context.Person.Thirst.Value <= 0;
    }
}
