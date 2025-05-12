using ComeForBrains.Localizations;

namespace ComeForBrainsSadConsoleUi.Screens;

public class GameScreen : ScreenObject
{
    protected GameScreen()
    {}

    public static ILocalization L => Environment.L;

    public static void SwitchToScreen(GameScreen newScreen)
    {
        if(Environment.Instance.Context.GameEndChecker.IsGameEnded())
            Game.Instance.Screen = new EndGameScreen();
        else
            Game.Instance.Screen = newScreen;
    }
}
