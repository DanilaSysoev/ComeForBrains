using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ProvisionsListPanel : ItemsListPanel<Provision>
{
    public ProvisionsListPanel(
        int width, int height, IEnumerable<Provision> items
    ) : base(width, height, items, L["Provisions"])
    {
    }
}
