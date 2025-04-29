using ComeForBrains.Engine;
using ComeForBrains.Engine.CommandProviding;

namespace ComeForBrainsConsoleUi.CommandProviding;

public class ConsoleStartScreenCommandProvider : StartScreenCommandProvider
{
    public override bool IsExitGameCommand(IGameContext gameContext)
    {
        return isExit;
    }

    public override bool IsStartGameCommand(IGameContext gameContext)
    {
        return isStart;
    }

    public override void WaitUserAction(IGameContext gameContext)
    {
        var keyPressed = Console.ReadKey();
        isStart = keyPressed.KeyChar == 's';
        isExit = keyPressed.KeyChar == 'e';
    }

    private bool isStart = false;
    private bool isExit = false;
}
