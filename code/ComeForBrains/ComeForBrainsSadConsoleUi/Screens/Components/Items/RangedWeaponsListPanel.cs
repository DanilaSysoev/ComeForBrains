using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class RangedWeaponsListPanel : ItemsListPanel<RangedWeapon>
{
    public RangedWeaponsListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["RangedWeapons"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(RangedWeapon item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
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

    protected override string GetInteractText(RangedWeapon item)
    {
        if(item.IsEquiped)
            return L["Unequip"];
        return L["Equip"];
    }

    protected override void Put(RangedWeapon item)
    {
        if (item.IsEquiped)
            Environment.Instance.Context.Person.Unequip(item);
        base.Put(item);
    }

    protected override bool CanTake(RangedWeapon item)
    {
        return base.CanTake(item) && !item.IsEquiped;
    }
}
