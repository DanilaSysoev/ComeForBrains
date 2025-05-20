using ComeForBrains.Core.GameWorld;
using ComeForBrainsSadConsoleUi.Service;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class LocationsPanel : BorderedPanel
{
    public LocationsPanel(int width, int height)
        : base(width, height)
    {
    }

    public void SetInfo(Settlement settlement)
    {
        Surface.Clear();
        string[] descrLines = settlement.Description.Wrap(Width - 2);
        int yPos = 1;
        for (int i = 0; i < descrLines.Length; i++)
            Surface.Print(1, yPos++, descrLines[i]);
        DrawBorder();
    }
    public void ClearPanel()
    {
        Surface.Clear();
        DrawBorder();
    }
}
