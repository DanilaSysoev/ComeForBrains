
namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class CampInfoPanel : BorderedPanel
{
    public CampInfoPanel(int width, int height) : base(width, height)
    {
        Fill();
    }

    public CampInfoPanel(
        int width,
        int height,
        Color foregroung,
        Color background
    ) : base(width, height, foregroung, background)
    {
        Fill();
    }

    public void Fill()
    {
        Surface.Print(2, 1, FortificationLabel());
        Surface.Print(2, 3, ComfortLabel());
    }

    private static string FortificationLabel()
    {
        return $"{L["Fortification"]}: " +
               $"{Environment.Instance.Context.Camp.Fortification:N2}";
    }

    private static string ComfortLabel()
    {
        return $"{L["Comfort"]}: " +
               $"{Environment.Instance.Context.Camp.Comfort:N2}";
    }
}
