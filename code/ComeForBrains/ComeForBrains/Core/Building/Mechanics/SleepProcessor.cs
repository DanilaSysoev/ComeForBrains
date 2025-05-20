using ComeForBrains.Core.Building.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public class SleepProcessor : MechanicBase
{
    internal double Multiplier { get; set; } = 1.0;

    public SleepProcessor(GameContext context)
        : base(context)
    {}

    public void Process()
    {
        Context.DaySleepModifier.Apply();
        RestoreEnergy();
        Context.DaySleepModifier.Undo();
        Context.DayStageSwitcher.Switch();
    }


    private void RestoreEnergy()
    {        
        var restoredEnergy = (GameSettings.EnergyRestoreBase +
                              Context.Camp.Comfort / 5) * Multiplier;
        Context.Person.Energy.Value += restoredEnergy;
    }
}
