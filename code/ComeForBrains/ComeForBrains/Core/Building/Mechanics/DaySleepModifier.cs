using ComeForBrains.Core.Building.Mechanics.Base;
using ComeForBrains.Localizations;

namespace ComeForBrains.Core.Building.Mechanics;

public class DaySleepModifier : IEnvironmentModifier
{
    public string Description =>
        Localization.GetInstance()["Sleep is more peaceful during the day"];

    public DaySleepModifier(GameContext context)
    {
        this.context = context;
    }

    public void Apply()
    {
        if (context.DayStage == DayStage.Day)
            context.SleepProcessor.Multiplier += GameSettings.DaySleepIncrease;
    }

    public void Undo()
    {
        if (context.DayStage == DayStage.Day)
            context.SleepProcessor.Multiplier -= GameSettings.DaySleepIncrease;
    }

    private readonly GameContext context;
}
