using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ProvisionsListPanel : ItemsListPanel<Provision>
{
    public ProvisionsListPanel(
        int width, int height, IEnumerable<Provision> items
    ) : base(width, height, L["Provisions"], items)
    {
    }

    protected override List<string> CreateLines(Provision item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["SatietyPower"]}: {item.SatietyPower:0.##}",
            $"{L["ThirstPower"]}: {item.ThirstPower:0.##}",
            $"{L["EnergyPower"]}: {item.EnergyPower:0.##}",
        ];
    }
}
