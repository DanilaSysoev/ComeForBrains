
using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class SleepScreen : GameScreen
{
    public SleepScreen()
    {
        CreateSleepPanel();
    }

    private void CreateSleepPanel()
    {
        Children.Add(
            new SleepPanel(
                Game.Instance.ScreenCellsX,
                Game.Instance.ScreenCellsY
            )
        );
    }
}
