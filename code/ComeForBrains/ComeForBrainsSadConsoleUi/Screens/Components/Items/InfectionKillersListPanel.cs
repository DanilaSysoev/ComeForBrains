using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class InfectionKillersListPanel : ItemsListPanel<InfectionKiller>
{
    public InfectionKillersListPanel(
        int width, int height, IEnumerable<InfectionKiller> items
    ) : base(width, height, L["InfectionKillers"], items)
    {
    }

    protected override List<string> CreateLines(InfectionKiller item)
    {
        return [
            $"{L["Weight"]}: {item.Weight:0.#####}",
            $"{L["SuccessChance"]}: {item.SuccessChance:0.##}",
            $"{L["HealthDamage"]}: {item.HealthDamage:0.##}",
            $"{L["EffectiveTime"]}: {item.EffectiveTime:0.##}"
        ];
    }
}
