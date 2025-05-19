using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class CampElementsListPanel : ItemsListPanel<CampElement>
{
    public CampElementsListPanel(
        int width, int height, IEnumerable<CampElement> items
    ) : base(width, height, L["CampElements"], items)
    {
    }

    protected override List<string> CreateLines(CampElement item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["Fortification"]}: {item.Fortification:0.##}",
            $"{L["Comfort"]}: {item.Comfort:0.##}",
            $"{L["Strength"]}: {item.Strength:0.##} / {item.MaxStrength:0.##}",
            $"{L["Condition"]}: {item.Condition:0.##}",
        ];
    }
}
