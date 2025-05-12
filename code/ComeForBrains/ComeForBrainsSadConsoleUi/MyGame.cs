using ComeForBrainsSadConsoleUi.Screens;
using SadConsole.Configuration;

namespace ComeForBrainsSadConsoleUi;

public static class MyGame
{
    public static void Main()
    {
        Settings.WindowTitle = "Come for brains!";

        Builder configuration = new Builder()
            .SetScreenSize(SadUiGameSettings.GameWidth,
                           SadUiGameSettings.GameHeight)
            .SetStartingScreen<MainMenuScreen>()
            .IsStartingScreenFocused(true)
            ;

        Game.Create(configuration);
        Game.Instance.Run();
        Game.Instance.Dispose();
    }
}
