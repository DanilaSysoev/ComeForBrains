using ComeForBrains.Core;
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class CampPanel : BorderedPanel
{
    public CampPanel(int width, int height) : base(width, height)
    {
        var controls = new ControlHost();
        CreateButtons(controls);
        SadComponents.Add(controls);
        DrawBorder();

        CreateDayInfo();
    }


    private void CreateDayInfo()
    {
        var text = $"{L["Day"]}: {Environment.Instance.Context.DayNumber}, ";
        if (Environment.Instance.Context.DayStage == DayStage.Day)
            text += L["Midday"];
        else
            text += L["Night"];

        Surface.Print(
            (Width - text.Length) / 2, DayInfoYPos, text, Foreground
        );
    }

    private void CreateButtons(ControlHost controls)
    {
        int buttonWidth = CalculateButtonWidth();        

        CreateButton(
            controls,
            buttonWidth,
            L["ToStorge"],
            ButtonsYPos,
            ToStorageScreen
        );
        CreateButton(
            controls,
            buttonWidth,
            L["ToPrepareRaid"],
            ButtonsYPos + 4,
            ToPrepareRaidScreen
        );
        CreateButton(
            controls,
            buttonWidth,
            L["Sleep"],
            ButtonsYPos + 8,
            ToSleepScreen
        );
    }

    private static void ToStorageScreen()
    {
        GameScreen.SwitchToScreen(new StorageScreen());
    }

    private static void ToPrepareRaidScreen()
    {
        GameScreen.SwitchToScreen(new PrepareRaidScreen());
    }

    private static void ToSleepScreen()
    {
        GameScreen.SwitchToScreen(new SleepScreen());
    }

    private static int CalculateButtonWidth()
    {
        return new int[] {
            L["ToStorge"].Length,
            L["ToPrepareRaid"].Length,
            L["Sleep"].Length
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


    private const int ButtonHeight = 3;
    private const int ButtonsYPos = 8;
    private const int DayInfoYPos = 2;
}
