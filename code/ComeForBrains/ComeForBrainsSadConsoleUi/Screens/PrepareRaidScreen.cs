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
        Children.Add(
            new EnvironmentInfoPanel(
                Game.Instance.ScreenCellsX,
                EnvInfoHeight
            )
        );
    }

    private void CreatePersonPanel()
    {
        int height = Game.Instance.ScreenCellsY -
                     ButtonsPanelHeight -
                     EnvInfoHeight;
        int width = (int)(Game.Instance.ScreenCellsX * PersonPanelWidthPerc);

        var panel = new PersonInfoPanel(width, height)
        {
            Position = new Point(0, EnvInfoHeight)
        };
        Children.Add(panel);
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
    private const int EnvInfoHeight = 5;
    private const double PersonPanelWidthPerc = 0.2;
}
