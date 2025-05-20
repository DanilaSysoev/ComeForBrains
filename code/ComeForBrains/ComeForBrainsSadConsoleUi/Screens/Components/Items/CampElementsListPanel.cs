using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class CampElementsListPanel : ItemsListPanel<CampElement>
{
    public CampElementsListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["CampElements"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(CampElement item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["Fortification"]}: {item.Fortification:0.##}",
            $"{L["Comfort"]}: {item.Comfort:0.##}",
            $"{L["Strength"]}: {item.Strength:0.##} / {item.MaxStrength:0.##}",
            $"{L["Condition"]}: {item.Condition:0.##}",
        ];
    }
}
