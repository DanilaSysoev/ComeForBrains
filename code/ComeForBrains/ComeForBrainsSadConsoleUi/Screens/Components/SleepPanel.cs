
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class SleepPanel : BorderedPanel
{
    public SleepPanel(int width, int height)
        : base(width, height)
    {
        var controls = new ControlHost();
        CreateSleepButton(controls);
        SadComponents.Add(controls);
        DrawBorder();
    }

    private void CreateSleepButton(ControlHost controls)
    {
        int buttonWidth = L[ButtonText].Length + 4;
        var button = new ButtonBox(buttonWidth, ButtonHeight);
        button.Text = L[ButtonText];
        
        int xPos = (Width - buttonWidth) / 2;
        int yPos = (Height - ButtonHeight) / 2;
        button.Position = new Point(xPos, yPos);

        button.Click += (_, _) => Sleep();
        
        controls.Add(button);
    }

    private static void Sleep()
    {
        Environment.Instance.Context.SleepProcessor.Process();
        GameScreen.SwitchToScreen(new CampScreen());
    }

    private const int ButtonHeight = 3;
    private const string ButtonText = "SleepButton";
}
