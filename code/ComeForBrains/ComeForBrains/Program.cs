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
            .SetScreenSize(GameSettings.GameWidth, GameSettings.GameHeight)
            .SetStartingScreen<MainMenuState>()
            .IsStartingScreenFocused(true)
            .ConfigureFonts(true)
            ;

        Game.Create(gameStartup);
        Game.Instance.Run();
        Game.Instance.Dispose();
    }
}
