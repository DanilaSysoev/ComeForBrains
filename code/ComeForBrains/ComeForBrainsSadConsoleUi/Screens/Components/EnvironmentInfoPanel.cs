namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class EnvironmentInfoPanel : BorderedPanel
{
    public EnvironmentInfoPanel(int width, int height)
        : base(width, height)
    {
        Surface.Print(
            2,
            2,
            $"{L[Environment.Instance.Context.DayStage.ToString()]}"
        );
    }
}
