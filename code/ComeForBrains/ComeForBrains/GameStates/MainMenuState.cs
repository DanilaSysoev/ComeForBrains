using SadConsole.Input;

namespace ComeForBrains.GameStates;

public class MainMenuState : GameState
{
    public MainMenuState()
    {
        surface = new ScreenSurface(
            Game.Instance.ScreenCellsX,
            Game.Instance.ScreenCellsY
        );
        Children.Add(surface);
        FillSurface();        
    }


    private void FillSurface()
    {
        for(int i = 0; i < Header.Length; ++i)
            surface.Print(0, i, Header[i]);
    }

    private readonly ScreenSurface surface;

    private readonly string[] Header = new string[] {
        " _____                         __           ",
        "/  __ \\                       / _|          ",
        "| /  \\/ ___  _ __ ___   ___  | |_ ___  _ __ ",
        "| |    / _ \\| '_ ` _ \\ / _ \\ |  _/ _ \\| '__|",
        "| \\__/\\ (_) | | | | | |  __/ | || (_) | |   ",
        " \\____/\\___/|_| |_| |_|\\___| |_| \\___/|_|   ",
        "       ______           _                   ",
        "       | ___ \\         (_)                  ",
        "       | |_/ /_ __ __ _ _ _ __  ___         ",
        "       | ___ \\ '__/ _` | | '_ \\/ __|        ",
        "       | |_/ / | | (_| | | | | \\__ \\        ",
        "       \\____/|_|  \\__,_|_|_| |_|___/        ",
        "                                          "
    };
}
