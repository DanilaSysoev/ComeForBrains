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

        var panel = new PersonInfoPanel(PersonPanelWidth, height)
        {
            Position = new Point(0, EnvInfoHeight)
        };
        Children.Add(panel);
    }

    private void CreateSettlementsPanel()
    {
        Children.Add(
            new SettlementsPanel(
                (Game.Instance.ScreenCellsX - PersonPanelWidth) / 2,
                Game.Instance.ScreenCellsY -
                     ButtonsPanelHeight -
                     EnvInfoHeight
            ) {
                Position = (PersonPanelWidth, EnvInfoHeight)
            }
        );
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
    private const int PersonPanelWidth = 36;
}
