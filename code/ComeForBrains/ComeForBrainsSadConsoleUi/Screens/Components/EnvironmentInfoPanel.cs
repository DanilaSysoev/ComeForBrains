using System.Text;
using ComeForBrains.Core;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class EnvironmentInfoPanel : BorderedPanel
{
    public EnvironmentInfoPanel(int width, int height)
        : base(width, height)
    {
        string info = CreateInfoText();
        Surface.Print(2, 2, info);
    }

    private static string CreateInfoText()
    {
        var context = Environment.Instance.Context;
        StringBuilder builder = new();
        builder.Append(L[context.DayStage.ToString()])
               .Append(": ");
        if (context.DayStage == DayStage.Day)
            builder.Append(context.DaySleepModifier.Description);
        else
            builder.Append(L["Nothing special"]);
        return builder.ToString();
    }
}
