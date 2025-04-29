using ComeForBrains.Engine.Commands;

namespace ComeForBrains.Engine.CommandProviding;

public abstract class StartScreenCommandProvider : CommandProvider
{
    internal override ICommand ProduceCommand(IGameContext gameContext)
    {
        if(IsStartGameCommand(gameContext))
            return new StartGameCommand();
        if (IsExitGameCommand(gameContext))
            return new ExitGameCommand();
        return new UnknownCommand();
    }

    public abstract bool IsStartGameCommand(IGameContext gameContext);
    public abstract bool IsExitGameCommand(IGameContext gameContext);
}
