﻿using SadConsole.Configuration;

namespace ComeForBrains;

static class Program
{
    public static void Main()
    {
        Settings.WindowTitle = "My SadConsole Game";

        Builder gameStartup = new Builder()
            .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
            .SetStartingScreen<ComeForBrains.Scenes.RootScreen>()
            .IsStartingScreenFocused(true)
            .ConfigureFonts(true)
            ;

        Game.Create(gameStartup);
        Game.Instance.Run();
        Game.Instance.Dispose();
    }
}