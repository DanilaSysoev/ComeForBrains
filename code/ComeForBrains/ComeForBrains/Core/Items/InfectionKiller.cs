using ComeForBrains.Service;

namespace ComeForBrains.Core.Items;

public class InfectionKiller : Item
{
    public int SuccessChance { get; init; }
    public double HealthDamage { get; init; }
    public double EffectiveTime { get; init; }

    public InfectionKiller(
        string name,
        string description,
        double weight,
        double passabilityPenalty,
        int successChance,
        double healthDamage,
        double effectiveTime
    ) : base(name, description, weight, passabilityPenalty)
    {
        SuccessChance = successChance;
        HealthDamage = healthDamage;
        EffectiveTime = effectiveTime;
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
    }

    public override bool Equals(object? obj)
    {
        return obj is InfectionKiller ic &&
               base.Equals(obj) &&
               SuccessChance == ic.SuccessChance &&
               Math.Abs(HealthDamage - ic.HealthDamage) < 0.000001 &&
               Math.Abs(EffectiveTime - ic.EffectiveTime) < 0.000001;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(), SuccessChance, HealthDamage, EffectiveTime
        );
    }
}
