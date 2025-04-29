using ComeForBrains.Core;

namespace ComeForBrains.Engine.Commands;

abstract class Command : ICommand
{
    public void Execute(IGameContext gameContext)
    {
        if(gameContext is GameContext gameContextImpl)
            Execute(gameContextImpl);
        throw new ArgumentException("Need GameContext object");
    }
    
    internal abstract void Execute(GameContext gameContext);
}
