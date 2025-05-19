using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public abstract class ItemsListPanel<TItem> : ItemListPanelBase
    where TItem : Item
{
    protected ItemsListPanel(
        int width,
        int height,
        string title,
        IEnumerable<TItem> items
    )
        : base(width, height, title, items)
    {
    }


    public override ScreenSurface CreateItemView(Item item)
    {
        return CreateItemView((TItem)item);
    }
    
    public ScreenSurface CreateItemView(TItem item)
    {
        lines = CreateLines(item);
        ScreenSurface result = new(CalcWidth(), CalcHeight());

        for(int i = 0; i < lines.Count; ++i)
            result.Print(0, i, lines[i]);

        return result;
    }

    protected abstract List<string> CreateLines(TItem item);

    virtual protected int CalcHeight()
    {
        return lines.Count;
    }

    virtual protected int CalcWidth()
    {
        return lines.Select(line => line.Length).Max();
    }

    private List<string> lines = [];
}
