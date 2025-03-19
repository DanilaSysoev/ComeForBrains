using ComeForBrains.GameStates;
using ComeForBrains.Service;
using SadConsole.Configuration;

namespace ComeForBrains;

static class Program
{
    private readonly static Localization L = Localization.GetInstance();

    public static void Main()
    {
        RandomProvider.Initialize(new SystemRandom());

        Settings.WindowTitle = L["Come for brains"];

        Builder gameStartup = new Builder()
            .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
            .SetStartingScreen<MainMenuState>()
            .IsStartingScreenFocused(true)
            .ConfigureFonts(true)
            ;

        Game.Create(gameStartup);
        Game.Instance.Run();
        Game.Instance.Dispose();
    }
}
