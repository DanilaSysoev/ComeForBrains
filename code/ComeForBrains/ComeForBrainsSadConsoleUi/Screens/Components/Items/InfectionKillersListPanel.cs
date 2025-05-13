using ComeForBrains.Core.Items;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public class InfectionKillersListPanel : ItemsListPanel<InfectionKiller>
{
    public InfectionKillersListPanel(
        int width, int height, IEnumerable<InfectionKiller> items
    ) : base(width, height, items, L["InfectionKillers"])
    {
    }
}
