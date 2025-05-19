using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class RangedWeaponsListPanel : ItemsListPanel<RangedWeapon>
{
    public RangedWeaponsListPanel(
        int width, int height, IEnumerable<RangedWeapon> items
    ) : base(width, height, L["RangedWeapons"], items)
    {
    }

    protected override List<string> CreateLines(RangedWeapon item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["BaseDamage"]}: {item.BaseDamage:0.##}",
            $"{L["InstantKillChance"]}: {item.InstantKillChance:0.##}",
            $"{L["BaseAccuracy"]}: {item.BaseAccuracy:0.##}",
            $"{L["EnergyConsumptionModifier"]}: {item.EnergyConsumptionModifier:0.##}",
            $"{L["MinEffectiveDistance"]}: {item.MinEffectiveDistance:0.##}",
            $"{L["MaxEffectiveDistance"]}: {item.MaxEffectiveDistance:0.##}",
            "",
            $"{L["NoiseDistance"]}: {item.NoiseDistance:0.##}"
        ];
    }
}
