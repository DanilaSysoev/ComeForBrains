using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ArmorsListPanel : ItemsListPanel<Armor>
{
    public ArmorsListPanel(
        int width, int height, IEnumerable<Armor> items
    ) : base(width, height, L["Armors"], items)
    {
    }

    protected override List<string> CreateLines(Armor item)
    {
        List<string> lines = [
            $"{L["Weight"]}: {item.Weight:0.#####}",
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
}
