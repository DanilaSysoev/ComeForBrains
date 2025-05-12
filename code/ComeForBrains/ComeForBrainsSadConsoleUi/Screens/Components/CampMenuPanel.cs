using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class CampMenuPanel : BorderedPanel
{
    public CampMenuPanel(int width, int height) : base(width, height)
    {
        var controls = new ControlHost();
        CreateButtons(controls);
        SadComponents.Add(controls);
        DrawBorder();
    }

    private static void CreateButtons(ControlHost controls)
    {
        int buttonWidth = CalculateButtonWidth();        

        CreateToMainMenu(controls, buttonWidth);
        CreateKillPerson(controls, buttonWidth);
    }

    private static int CalculateButtonWidth()
    {
        return Math.Max(
            L["MainMenu"].Length,
            L["KillPerson"].Length
        ) + 4;
    }

    private static void CreateToMainMenu(ControlHost controls, int buttonWidth)
    {
        var button = new ButtonBox(buttonWidth, ButtonHeight);
        button.Text = L["MainMenu"];
        
        int xPos = Game.Instance.ScreenCellsX / 2 - XCenterOffset - buttonWidth;
        button.Position = new Point(xPos, YPos);

        button.Click += (_, _) => SaveWorldAndGoToMainMenu();
        
        controls.Add(button);
    }

    private static void CreateKillPerson(ControlHost controls, int buttonWidth)
    {        
        var button = new ButtonBox(buttonWidth, ButtonHeight);
        button.Text = L["KillPerson"];

        int xPos = Game.Instance.ScreenCellsX / 2 + XCenterOffset;
        button.Position = new Point(xPos, YPos);

        button.Click += (_, _) => KillPersonAndGoToMainMenu();

        controls.Add(button);
    }

    private static void KillPersonAndGoToMainMenu()
    {
        GameScreen.SwitchToScreen(new MainMenuScreen());
    }
    private static void SaveWorldAndGoToMainMenu()
    {
        GameScreen.SwitchToScreen(new MainMenuScreen());
    }

    private const int ButtonHeight = 3;
    private const int YPos = 2;
    private const int XCenterOffset = 3;
}
