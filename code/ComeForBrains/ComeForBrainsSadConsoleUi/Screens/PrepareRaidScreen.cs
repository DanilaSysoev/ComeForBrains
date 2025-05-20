using ComeForBrains.Core.GameWorld;
using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class PrepareRaidScreen : GameScreen
{
    public SettlementsPanel SettlementPanel { get; private set; } = null!;
    public LocationsPanel LocationsPanel { get; private set; } = null!;

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
        SettlementPanel = new SettlementsPanel(
            (Game.Instance.ScreenCellsX - PersonPanelWidth) / 2,
            Game.Instance.ScreenCellsY -
                    ButtonsPanelHeight -
                    EnvInfoHeight
        ) {
            Position = (PersonPanelWidth, EnvInfoHeight)
        };

        SettlementPanel.ListBox.SelectedItemChanged += 
            (_, _) => SelectSettlement();

        Children.Add(SettlementPanel);
    }

    private void SelectSettlement()
    {
        if(SettlementPanel.ListBox.SelectedItem is null)
        {
            LocationsPanel.ClearPanel();
        }
        else
        {
            LocationsPanel.SetInfo(
                (Settlement)SettlementPanel.ListBox.SelectedItem
            );
        }
    }

    private void CreateLocationsPanel()
    {
        var width = (Game.Instance.ScreenCellsX - PersonPanelWidth) / 2;
        LocationsPanel = new LocationsPanel(
            width,
            Game.Instance.ScreenCellsY -
                    ButtonsPanelHeight -
                    EnvInfoHeight
        ) {
            Position = (PersonPanelWidth + width, EnvInfoHeight)
        };
        Children.Add(LocationsPanel);
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
