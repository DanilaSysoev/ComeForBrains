using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class MedicinesListPanel : ItemsListPanel<Medicine>
{
    public MedicinesListPanel(
        int width, int height, IEnumerable<Medicine> items
    ) : base(width, height, items, L["Medicines"])
    {
    }
}
