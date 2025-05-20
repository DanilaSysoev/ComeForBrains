using ComeForBrains.Core.Building.Items;
using ComeForBrains.Service;

namespace ComeForBrains.Core.Items;

public class InfectionKiller : Item
{
    public double SuccessChance { get; init; }
    public double HealthDamage { get; init; }
    public double EffectiveTime { get; init; }

    public InfectionKiller(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        double successChance,
        double healthDamage,
        double effectiveTime
    ) : base(name, description, weight, passabilityPenalty)
    {
        SuccessChance = successChance;
        HealthDamage = healthDamage;
        EffectiveTime = effectiveTime;
    }

    public InfectionKiller(InfectionKillerBuilder builder)
        : base(builder)
    {
        SuccessChance = builder.SuccessChance;
        HealthDamage = builder.HealthDamage;
        EffectiveTime = builder.EffectiveTime;
    }
    
    public override void Interact(GameContext context)
    {
        context.Person.Health.Value -= HealthDamage;

        if(context.Person.InfectionTime <= EffectiveTime &&
           RandomProvider.Instance.Try(SuccessChance))
        {
            context.Person.KillInfection();
        }

        context.Person.Inventory.RemoveItem(this);
        context.Camp.RemoveFromStorage(this);
    }
}
