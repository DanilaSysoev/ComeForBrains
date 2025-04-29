using ComeForBrains.Core;

namespace ComeForBrains.Engine.Commands;

class ExitGameCommand : Command
{
    internal override void Execute(GameContext gameContext)
    {
        gameContext.IsGameEnded = true;
    }
}
