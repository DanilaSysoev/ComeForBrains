using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class ListBoxPanel : BorderedPanel
{
    public string Title { get; private set; }
    public ListBox ListBox { get; private set; } = null!;

    protected ListBoxPanel(
        int width,
        int height,
        string title
    )
        : base(width, height)
    {
        Title = title;

        CreateListBox();
    }

    private void CreateListBox()
    {
        ListBox = new ListBox(Width - 2, Height - 4);
        ListBox.Position = (1, 3);
        ListBox.FocusOnMouseClick = true;
        
        ControlHost controls = [ListBox];
        SadComponents.Add(controls);
        DrawTitle();
        DrawBorder();
    }

    private void DrawTitle()
    {
        Surface.Print(1, 1, Title);
        Surface.DrawLine((1, 2), (Width - 1, 2), '-');
    }
}
