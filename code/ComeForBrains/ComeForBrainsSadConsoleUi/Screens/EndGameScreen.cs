using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class EndGameScreen : GameScreen
{
    public EndGameScreen()
    {
        Children.Add(
            new GameEndPanel(
                Game.Instance.ScreenCellsX,
                Game.Instance.ScreenCellsY
            )
        );
    }
}