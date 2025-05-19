using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MedicinesListPanel : ItemsListPanel<Medicine>
{
    public MedicinesListPanel(
        int width, int height, IEnumerable<Medicine> items
    ) : base(width, height, L["Medicines"], items)
    {
    }

    protected override List<string> CreateLines(Medicine item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["HealingPower"]}: {item.HealingPower:0.##}",
            $"{L["Count"]}: {item.Count}"
        ];
    }
}
