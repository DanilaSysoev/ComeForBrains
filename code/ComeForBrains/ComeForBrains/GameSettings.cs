namespace ComeForBrains;

public static class GameSettings
{
    public readonly static int GameWidth = 90;
    public readonly static int GameHeight = 30;

    public readonly static long FeatureBase = 10;
    public readonly static long BaseWeight = 50;
    public readonly static double MaxArmorThikness = 1.0;
    public readonly static double ArmorBaseValue = 0;
    public readonly static int NemberOfIterationsInRandomDistributor = 10;
    public readonly static string Locale = "Ru";
    public readonly static string PathToLocalizations = Path.Combine("Data", "Localizations");
    public readonly static string PathToWorlds = "Worlds";
}
