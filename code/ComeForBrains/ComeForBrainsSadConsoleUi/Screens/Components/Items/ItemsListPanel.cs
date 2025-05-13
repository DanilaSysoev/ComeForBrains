using ComeForBrains.Core.Items;
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ItemsListPanel<TItem> : BorderedPanel
    where TItem : Item
{
    public string Title { get; private set; }

    public ItemsListPanel(
        int width,
        int height,
        IEnumerable<TItem> items,
        string title
    )
        : base(width, height)
    {
        Items = [.. items];
        Title = title;

        CreateListBox();
    }

    private void CreateListBox()
    {
        ListBox listBox = new ListBox(Width - 2, Height - 4);
        listBox.Position = (1, 3);
        foreach (var item in Items)
            listBox.Items.Add(item);
        
        ControlHost controls = new ControlHost();
        controls.Add(listBox);
        SadComponents.Add(controls);
        DrawTitle();
        DrawBorder();
    }

    private void DrawTitle()
    {
        Surface.Print(1, 1, Title);
        Surface.DrawLine((1, 2), (Width - 1, 2), '-');
    }

    private List<TItem> Items { get; }
}
