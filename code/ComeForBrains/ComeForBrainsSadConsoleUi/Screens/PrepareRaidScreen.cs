using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class PrepareRaidScreen : GameScreen
{
    public PrepareRaidScreen()
    {
        CreateEnvironmentInfoPanel();
        CreatePersonPanel();
        CreateSettlementsPanel();
        CreateLocationsPanel();
        CreateButtonsPanel();
    }

    private void CreateEnvironmentInfoPanel()
    {
        
    }

    private void CreatePersonPanel()
    {
        
    }

    private void CreateSettlementsPanel()
    {
        
    }

    private void CreateLocationsPanel()
    {
        
    }

    private void CreateButtonsPanel()
    {
        PrepareToRaidButtonsPanel buttonsPanel =
            new PrepareToRaidButtonsPanel(
                Game.Instance.ScreenCellsX, ButtonsPanelHeight
            ) {
                Position = new Point(0, Game.Instance.ScreenCellsY - ButtonsPanelHeight)
            };
        Children.Add(buttonsPanel);
    }

    private const int ButtonsPanelHeight = 5;
}
