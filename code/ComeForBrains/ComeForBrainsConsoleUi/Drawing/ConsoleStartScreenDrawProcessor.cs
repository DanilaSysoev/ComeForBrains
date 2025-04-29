using ComeForBrains.Engine;
using ComeForBrains.Engine.Drawing;

namespace ComeForBrainsConsoleUi.Drawing;

public class ConsoleStartScreenDrawProcessor : StartScreenDrawProcessor
{
    public ConsoleStartScreenDrawProcessor()
    {
        buffer = new char[UiSettings.GameHeight + 2][];
        for(int y = 0; y < buffer.Length; y++)
            buffer[y] = new char[UiSettings.GameWidth + 2];
        ClearBuffer();
    }

    public override void DrawDecorations(IGameContext gameContext)
    {
    }

    public override void DrawExitGameSelector(IGameContext gameContext)
    {
        Array.Copy("e: Exit".ToCharArray(),
                   0,
                   buffer[buffer.Length - 4],
                   (buffer[buffer.Length - 4].Length - 7) / 2, 7);
    }

    public override void DrawStartGameSelector(IGameContext gameContext)
    {
        Array.Copy("s: Start".ToCharArray(),
                   0,
                   buffer[buffer.Length - 5],
                   (buffer[buffer.Length - 5].Length - 8) / 2, 8);
    }

    public override void DrawTitle(IGameContext gameContext)
    {
        Array.Copy("Come for brains".ToCharArray(),
                   0,
                   buffer[2],
                   (buffer[2].Length - 15) / 2, 15);
    }

    public override void PostDraw(IGameContext gameContext)
    {
        Console.SetCursorPosition(0, 0);
        for(int y = 0; y < buffer.Length; y++)
        {
            for (int x = 0; x < buffer[y].Length; x++)
            {
                Console.Write(buffer[y][x]);
            }
            Console.WriteLine();
        }
    }

    public override void PreDraw(IGameContext gameContext)
    {
        ClearBuffer();
        Console.Clear();
    }


    private void ClearBuffer()
    {
        for (int y = 1; y < buffer.Length - 1; y++)
        {
            for (int x = 1; x < buffer[y].Length - 1; x++)
            {
                buffer[y][x] = ' ';
            }
        }
        for (int y = 0; y < buffer.Length; y++)
        {
            buffer[y][0] = '#';
            buffer[y][buffer[y].Length - 1] = '#';
        }
        for (int x = 0; x < buffer[0].Length; x++)
        {
            buffer[0][x] = '#';
            buffer[buffer.Length - 1][x] = '#';
        }
    }

    private readonly char[][] buffer;
}
