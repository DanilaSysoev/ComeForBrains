using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class ItemsListPanel<TItem> : BorderedPanel
    where TItem : Item
{
    public ItemsListPanel(int width, int height, IEnumerable<TItem> items)
        : base(width, height)
    {
        Items = [.. items];

        CreateListBox();
    }


    private void CreateListBox()
    {
        throw new NotImplementedException();
    }

    private List<TItem> Items { get; }
}
