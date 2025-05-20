using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ArmorsListPanel : ItemsListPanel<Armor>
{
    public ArmorsListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["Armors"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(Armor item)
    {
        List<string> lines = [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["Thikness"]}: {item.Thikness:0.##}",
            $"{L["InfectionModifier"]}: {item.InfectionModifier:0.##}",
            $"{L["ArmorValue"]}: {item.ArmorValue:0.##}",
            $"{L["EnergyConsumptionModifier"]}: {item.EnergyConsumptionModifier:0.##}",
            $"{L["BodyParts"]}:"
        ];
        foreach (var bodyPart in item.BodyParts)
            lines.Add($"  {L[bodyPart.ToString()]}");
        return lines;
    }

    protected override string GetInteractText(Armor item)
    {
        if(item.IsEquiped)
            return L["Unequip"];
        return L["Equip"];
    }

    protected override void Put(Armor item)
    {
        if (item.IsEquiped)
            Environment.Instance.Context.Person.Unequip(item);
        base.Put(item);
    }

    protected override bool CanTake(Armor item)
    {
        return base.CanTake(item) && !item.IsEquiped;
    }
}
