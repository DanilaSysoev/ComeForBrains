using ComeForBrains.Core;

namespace ComeForBrains.Engine.Commands;

class StartGameCommand : Command
{
    internal override void Execute(GameContext gameContext)
    {
        System.Console.WriteLine("Game started!");
        gameContext.IsGameEnded = false;
    }
}
