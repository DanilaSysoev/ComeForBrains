using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public abstract class ItemListPanelBase : ListBoxPanel
{
    protected ItemListPanelBase(
        int width,
        int height,
        string title,
        IItemsProvider itemsProvider
    )
        : base(width, height, title)
    {
        Items = [.. itemsProvider.GetItems()];
        foreach (var item in Items)
            ListBox.Items.Add(item);

        ItemsProvider = itemsProvider;
    }

    public abstract ScreenSurface CreateItemView(Item item);

    protected List<Item> Items { get; set; }
    protected IItemsProvider ItemsProvider { get; private set; }
    public ButtonBox? InteractButton { get; protected set; }
    public ButtonBox? TakeButton { get; protected set; }
    public ButtonBox? PutButton { get; protected set; }
}
