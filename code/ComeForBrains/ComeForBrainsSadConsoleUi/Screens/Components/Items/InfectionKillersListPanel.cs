using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class InfectionKillersListPanel : ItemsListPanel<InfectionKiller>
{
    public InfectionKillersListPanel(
        int width, int height, IItemsProvider itemsProvider
    ) : base(width, height, L["InfectionKillers"], itemsProvider)
    {
    }

    protected override List<string> CreateLines(InfectionKiller item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####} {L["g"]}",
            $"{L["SuccessChance"]}: {item.SuccessChance:0.##}",
            $"{L["HealthDamage"]}: {item.HealthDamage:0.##}",
            $"{L["EffectiveTime"]}: {item.EffectiveTime:0.##}"
        ];
    }
}
