using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MedicinesListPanel : ItemsListPanel<Medicine>
{
    public MedicinesListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["Medicines"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(Medicine item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["HealingPower"]}: {item.HealingPower:0.##}",
            $"{L["Count"]}: {item.Count}"
        ];
    }
}
