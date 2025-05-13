using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class RangedWeaponsListPanel : ItemsListPanel<RangedWeapon>
{
    public RangedWeaponsListPanel(
        int width, int height, IEnumerable<RangedWeapon> items
    ) : base(width, height, items, L["RangedWeapons"])
    {
    }
}
