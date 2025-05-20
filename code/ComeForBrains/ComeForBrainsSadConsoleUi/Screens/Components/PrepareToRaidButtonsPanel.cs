using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class PrepareToRaidButtonsPanel : BorderedPanel
{
    public ButtonBox StartRaidButton { get; private set; } = null!;
    public ButtonBox PackThingsButton { get; private set; } = null!;

    public PrepareToRaidButtonsPanel(int width, int height)
        : base(width, height)
    {
        controls = new ControlHost();

        CreatePackThingsButton();
        CreateToCampButton();
        CreateStartRaidButton();

        SadComponents.Add(controls);

        DrawBorder();
    }

    private void CreatePackThingsButton()
    {
        int bWidth = CalcButtonWidth();
        int yPos = CalcYPos();
        int xPos = Position.X + ButtonMargin;
        PackThingsButton = new ButtonBox(bWidth, ButtonHeight)
        {
            Position = (xPos, yPos),
            Text = L["Pack Things"]
        };
        controls.Add(PackThingsButton);
    }

    private void CreateToCampButton()
    {  
        int bWidth = CalcButtonWidth();
        int yPos = CalcYPos();
        int xPos = Position.X + ButtonMargin + bWidth;
        PackThingsButton = new ButtonBox(bWidth, ButtonHeight)
        {
            Position = (xPos, yPos),
            Text = L["Back to Camp"]
        };
        controls.Add(PackThingsButton);
    }

    private void CreateStartRaidButton()
    {
        int bWidth = CalcButtonWidth();
        int yPos = CalcYPos();
        int xPos = Position.X + Width - (bWidth + ButtonMargin);
        StartRaidButton = new ButtonBox(bWidth, ButtonHeight)
        {
            Position = (xPos, yPos),
            Text = L["Start Raid"],
            IsEnabled = false
        };
        controls.Add(StartRaidButton);
    }

    private int CalcYPos()
    {
        return Position.Y + (Height - ButtonHeight) / 2;
    }

    private static int CalcButtonWidth()
    {
        return new int[] {
            L["Pack Things"].Length,
            L["Back to Camp"].Length,
            L["Start Raid"].Length
        }.Max() + ButtonPadding * 2 + 2;
    }

    private readonly ControlHost controls;

    private const int ButtonHeight = 3;
    private const int ButtonPadding = 1;
    private const int ButtonMargin = 2;
}
