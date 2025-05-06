
using ComeForBrainsSadConsoleUi.Screens.Components;

namespace ComeForBrainsSadConsoleUi.Screens;

public class CampScreen : GameScreen
{
    public CampScreen()
    {
        CreatePersonInfoPanel();
        CreateCampInfoPanel();
        CreateCampPanel();        
        CreateMenu();
    }


    private void CreatePersonInfoPanel()
    {
        int height = (int)(Game.Instance.ScreenCellsY * CampPanelHeight);
        int width = (int)(Game.Instance.ScreenCellsX * (1 - CampPanelWidth) / 2);

        var panel = new PersonInfoPanel(width, height);
        Children.Add(panel);
    }

    private void CreateCampInfoPanel()
    {
        int height = (int)(Game.Instance.ScreenCellsY * CampPanelHeight);
        int width = (int)(Game.Instance.ScreenCellsX * (1 - CampPanelWidth) / 2);
        int xPos = Game.Instance.ScreenCellsX - width;

        var panel = new CampInfoPanel(width, height);
        panel.Position = new Point(xPos, 0);
        Children.Add(panel);
    }

    private void CreateCampPanel()
    {
        int height = (int)(Game.Instance.ScreenCellsY * CampPanelHeight);
        int sideWidth = (int)(Game.Instance.ScreenCellsX * (1 - CampPanelWidth) / 2);
        int width = Game.Instance.ScreenCellsX - 2 * sideWidth;
        int xPos = sideWidth;

        var panel = new CampPanel(width, height);
        panel.Position = new Point(xPos, 0);
        Children.Add(panel);
    }

    private void CreateMenu()
    {
        int topHeight = (int)(Game.Instance.ScreenCellsY * CampPanelHeight);
        int height = Game.Instance.ScreenCellsY - topHeight;
        int width = Game.Instance.ScreenCellsX;
        int yPos = topHeight;

        var panel = new CampMenuPanel(width, height);
        panel.Position = new Point(0, yPos);
        Children.Add(panel);
    }


    private const double CampPanelWidth = 0.6;
    private const double CampPanelHeight = 0.8;
}
