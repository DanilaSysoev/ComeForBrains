using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class GameEndPanel : BorderedPanel
{
    public GameEndPanel(int width, int height) : base(width, height)
    {
        CreateButtons();
        CreateTitle();
    }

    private void CreateTitle()
    {
        var titleSurface = new ScreenSurface(
            GetTitleWidth(),
            GetTitleHeight()
        );
        titleSurface.Position = new Point(
            (Width - GetTitleWidth()) / 2, TitleY
        );
        for (int line = 0; line < Title.Length; ++line)
        {
            titleSurface.Print(
                0, line, Title[line], Color.Red
            );
        }
        Children.Add(titleSurface);
    }

    private void CreateButtons()
    {
        var controls = new ControlHost();
        CreateButtons(controls);
        SadComponents.Add(controls);
        DrawBorder();
    }

    private void CreateButtons(ControlHost controls)
    {
        int buttonWidth = CalculateButtonWidth();        
        int titleHeight = GetTitleHeight();


        CreateButton(
            controls,
            buttonWidth,
            L["ToMainMenu"],
            titleHeight + YPos + TitleY,
            ToMainMenu
        );
        CreateButton(
            controls,
            buttonWidth,
            L["ExitGame"],
            titleHeight + YPos + TitleY + 4,
            ExitGame
        );
    }

    private static void ToMainMenu()
    {
        ClearGameFiles();
        Game.Instance.Screen = new MainMenuScreen();
    }

    private static void ExitGame()
    {
        ClearGameFiles();
        Game.Instance.MonoGameInstance.Exit();
    }

    private static void ClearGameFiles()
    {
        throw new NotImplementedException();
    }

    private static int CalculateButtonWidth()
    {
        return new int[] {
            L["ToMainMenu"].Length,
            L["ExitGame"].Length
        }.Max() + 4;        
    }

    private void CreateButton(
        ControlHost controls,
        int buttonWidth,
        string buttonText,
        int yPos,
        Action onClick
    )
    {
        var button = new ButtonBox(buttonWidth, ButtonHeight);
        button.Text = buttonText;
        
        int xPos = (Width - buttonWidth) / 2;
        button.Position = new Point(xPos, yPos);

        button.Click += (_, _) => onClick();
        
        controls.Add(button);
    }

    private int GetTitleHeight()
    {
        return Title.Length;
    }

    private int GetTitleWidth()
    {
        return Title.Max(x => x.Length);
    }



    private const int ButtonHeight = 3;
    private const int YPos = 3;
    private const int TitleY = 2;
    private readonly string[] Title = L["GameTitle"].Split('\n');
}
