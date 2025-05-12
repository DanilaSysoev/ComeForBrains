namespace ComeForBrains;

public static class GameSettings
{
    public readonly static long FeatureBase = 10;
    public readonly static long BaseWeight = 50;
    public readonly static double MaxArmorThikness = 1.0;
    public readonly static double ArmorBaseValue = 0;
    public readonly static int NemberOfIterationsInRandomDistributor = 10;
    public readonly static double DaySleepIncrease = 0.5;
    public readonly static double EnergyRestoreBase = 30;
    public readonly static double InfectionMaxHealthDamage = 10;
    public readonly static double BaseHeal = 1;
    public readonly static double SatietyConsumption = 5;
    public readonly static double ThirstConsumption = 20;
    public readonly static string Locale = "En";
    public readonly static string PathToLocalizations = Path.Combine("Data", "Localizations");
    public readonly static string PathToWorlds = "Worlds";
}
