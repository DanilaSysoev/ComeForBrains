using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public abstract class ItemListPanelBase : ListBoxPanel
{
    protected ItemListPanelBase(
        int width,
        int height,
        string title,
        IEnumerable<Item> items
    )
        : base(width, height, title)
    {
        Items = [.. items];
        foreach (var item in Items)
            ListBox.Items.Add(item);
    }

    public abstract ScreenSurface CreateItemView(Item item);

    private List<Item> Items { get; }
}
