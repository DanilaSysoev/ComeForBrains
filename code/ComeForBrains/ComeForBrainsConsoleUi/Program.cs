using ComeForBrains.Core;
using ComeForBrains.Engine;
using ComeForBrainsConsoleUi.CommandProviding;
using ComeForBrainsConsoleUi.Drawing;

namespace ComeForBrainsConsoleUi;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Game game = new Game(
            new ConsoleStartScreenDrawProcessor(),
            new ConsoleStartScreenCommandProvider(),
            new DummyUpdateProcessor(),
            new GameContext(new DummyGameContextBuilder())
        );

        game.Start();
    }
}
