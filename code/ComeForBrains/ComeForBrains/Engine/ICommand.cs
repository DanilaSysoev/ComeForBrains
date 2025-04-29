namespace ComeForBrains.Engine;

public interface ICommand
{
    void Execute(IGameContext gameContext);
}
