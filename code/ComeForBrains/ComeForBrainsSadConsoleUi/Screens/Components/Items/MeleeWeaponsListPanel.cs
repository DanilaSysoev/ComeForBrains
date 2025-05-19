using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MeleeWeaponsListPanel : ItemsListPanel<MeleeWeapon>
{
    public MeleeWeaponsListPanel(
        int width, int height, IEnumerable<MeleeWeapon> items
    ) : base(width, height, L["MeleeWeapons"], items)
    {
    }

    protected override List<string> CreateLines(MeleeWeapon item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["BaseDamage"]}: {item.BaseDamage:0.##}",
            $"{L["InstantKillChance"]}: {item.InstantKillChance:0.##}",
            $"{L["BaseAccuracy"]}: {item.BaseAccuracy:0.##}",
            $"{L["EnergyConsumptionModifier"]}: {item.EnergyConsumptionModifier:0.##}",
            $"{L["MinEffectiveDistance"]}: {item.MinEffectiveDistance:0.##}",
            $"{L["MaxEffectiveDistance"]}: {item.MaxEffectiveDistance:0.##}"
        ];
    }
}
