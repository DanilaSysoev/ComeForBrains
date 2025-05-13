using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ArmorsListPanel : ItemsListPanel<Armor>
{
    public ArmorsListPanel(
        int width, int height, IEnumerable<Armor> items
    ) : base(width, height, items, L["Armors"])
    {
    }
}
