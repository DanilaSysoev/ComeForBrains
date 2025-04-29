namespace ComeForBrains.Engine.CommandProviding;

public abstract class CommandProvider : ICommandProvider
{
    public ICommand GetNextCommand(IGameContext gameContext)
    {
        WaitUserAction(gameContext);
        return ProduceCommand(gameContext);
    }

    internal abstract ICommand ProduceCommand(IGameContext gameContext);

    public abstract void WaitUserAction(IGameContext gameContext);
}
