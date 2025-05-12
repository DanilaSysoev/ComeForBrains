using ComeForBrains.Core.Building.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public class SleepProcessor : MechanicBase
{
    public SleepProcessor(GameContext context)
        : base(context)
    {}

    public void Process()
    {
        RestoreEnergy();
        Context.DayStageSwitcher.Switch();
    }


    private void RestoreEnergy()
    {
        double multiplier = 1.0;
        if (Context.DayStage == DayStage.Day)
            multiplier += GameSettings.DaySleepIncrease;
        
        var restoredEnergy = (GameSettings.EnergyRestoreBase +
                              Context.Camp.Comfort / 5) * multiplier;
        Context.Person.Energy.Value += restoredEnergy;
    }
}
