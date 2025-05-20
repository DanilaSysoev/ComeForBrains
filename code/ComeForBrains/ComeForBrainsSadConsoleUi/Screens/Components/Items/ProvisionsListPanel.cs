using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class ProvisionsListPanel : ItemsListPanel<Provision>
{
    public ProvisionsListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["Provisions"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(Provision item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["SatietyPower"]}: {item.SatietyPower:0.##}",
            $"{L["ThirstPower"]}: {item.ThirstPower:0.##}",
            $"{L["EnergyPower"]}: {item.EnergyPower:0.##}",
        ];
    }
}
