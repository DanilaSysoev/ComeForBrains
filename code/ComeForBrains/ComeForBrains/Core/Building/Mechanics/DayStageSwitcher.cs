using ComeForBrains.Core.Building.Mechanics.Base;

namespace ComeForBrains.Core.Building.Mechanics;

public class DayStageSwitcher : MechanicBase
{
    public DayStageSwitcher(GameContext context)
        : base(context)
    {}

    public void Switch()
    {
        UpdatePersonState();
        if (Context.DayStage == DayStage.Day)
            Context.DayStage = DayStage.Night;
        else
            GoToNextDay();
    }


    private void UpdatePersonState()
    {
        ProcessInfection();
        RestoreHealth();
        ConsumeSatiety();
        ConsumeThirst();
    }

    private void ProcessInfection()
    {
        if (!Context.Person.IsInfected)
            return;

        Context.Person.Health.MaxValue -= GameSettings.InfectionMaxHealthDamage;
    }

    private void RestoreHealth()
    {
        if (Context.Person.PhysiqueModifier <= 0)
            return;

        Context.Person.Health.Value +=
            Context.Person.PhysiqueModifier +
            GameSettings.BaseHeal;
    }

    private void ConsumeSatiety()
    {
        Context.Person.Satiety.Value -= GameSettings.SatietyConsumption;
    }

    private void ConsumeThirst()
    {
        Context.Person.Thirst.Value -= GameSettings.ThirstConsumption;
    }

    private void GoToNextDay()
    {
        EndOfDayOperaions();
        ++Context.DayNumber;
        Context.DayStage = DayStage.Day;
    }

    private void EndOfDayOperaions()
    {
        Context.Camp.DamageCampAtNight();
    }
}
