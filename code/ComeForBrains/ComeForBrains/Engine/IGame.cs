namespace ComeForBrains.Engine;

public interface IGame
{
    void SetState(
        IDrawProcessor drawProcessor,
        ICommandProvider commandProvider,
        IUpdateProcessor updateProcessor
    );
}
