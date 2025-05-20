using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class FuelListPanel : ItemsListPanel<Fuel>
{
    public FuelListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["Fuels"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(Fuel item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["Volume"]}: {item.Volume:0.##}"
        ];
    }

    protected override string GetInteractText(Fuel item)
    {
        return $"{L["Refuel"]} " +
               $"{item.CalcMaxRefuel(Environment.Instance.Context):0.##}";
    }
}
