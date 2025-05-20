using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MeleeWeaponsListPanel : ItemsListPanel<MeleeWeapon>
{
    public MeleeWeaponsListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["MeleeWeapons"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(MeleeWeapon item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["BaseDamage"]}: {item.BaseDamage:0.##}",
            $"{L["InstantKillChance"]}: {item.InstantKillChance:0.##}",
            $"{L["BaseAccuracy"]}: {item.BaseAccuracy:0.##}",
            $"{L["EnergyConsumptionModifier"]}: {item.EnergyConsumptionModifier:0.##}",
            $"{L["MinEffectiveDistance"]}: {item.MinEffectiveDistance:0.##}",
            $"{L["MaxEffectiveDistance"]}: {item.MaxEffectiveDistance:0.##}"
        ];
    }

    protected override string GetInteractText(MeleeWeapon item)
    {
        if(item.IsEquiped)
            return L["Unequip"];
        return L["Equip"];
    }

    protected override void Put(MeleeWeapon item)
    {
        if (item.IsEquiped)
            Environment.Instance.Context.Person.Unequip(item);
        base.Put(item);
    }

    protected override bool CanTake(MeleeWeapon item)
    {
        return base.CanTake(item) && !item.IsEquiped;
    }
}
