using ComeForBrains.Localizations;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class BasePanel : ScreenSurface
{
    public BasePanel(int width, int height) : base(width, height)
    {
        Surface.DefaultBackground = SadUiGameSettings.DefaultBackground;
        Surface.DefaultForeground = SadUiGameSettings.DefaultForeground;
    }

    public static ILocalization L => Environment.L;
}
