namespace ComeForBrains.Core.Building.Items;

public class InfectionKillerBuilder : ItemBuilder
{
    public int SuccessChance { get; set; }
    public double HealthDamage { get; set; }
    public double EffectiveTime { get; set; }
}
