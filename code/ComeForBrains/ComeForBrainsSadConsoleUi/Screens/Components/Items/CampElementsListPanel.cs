using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class CampElementsListPanel : ItemsListPanel<CampElement>
{
    public CampElementsListPanel(
        int width, int height, IEnumerable<CampElement> items
    ) : base(width, height, items, L["CampElements"])
    {
    }
}
