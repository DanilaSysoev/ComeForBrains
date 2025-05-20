namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class SettlementsPanel : ListBoxPanel
{
    public SettlementsPanel(
        int width, int height
    ) : base(width, height, L["Known accessible settlements"])
    {
        foreach(var settlement in Environment.Instance.World.Settlements)
            ListBox.Items.Add(settlement);
    }
}
