using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MeleeWeaponsListPanel : ItemsListPanel<MeleeWeapon>
{
    public MeleeWeaponsListPanel(
        int width, int height, IEnumerable<MeleeWeapon> items
    ) : base(width, height, items, L["MeleeWeapons"])
    {
    }
}
