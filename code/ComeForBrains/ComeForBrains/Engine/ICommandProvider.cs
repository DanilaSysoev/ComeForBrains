namespace ComeForBrains.Engine;

public interface ICommandProvider
{
    ICommand GetNextCommand(IGameContext gameContext);
}
