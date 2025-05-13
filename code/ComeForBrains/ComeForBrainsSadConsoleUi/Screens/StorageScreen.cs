using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class StorageScreen : GameScreen
{
    public StorageScreen()
    {
        Children.Add(
            new StoragePanel(
                Game.Instance.ScreenCellsX,
                Game.Instance.ScreenCellsY
            )
        );
    }
}
