using System.Text.Json;

namespace ComeForBrains.Localizations;

public class Localization : ILocalization
{
    public static ILocalization GetInstance() {
        if (instance is null) {
            throw new InvalidOperationException(
                "Localization is not initialized"
            );
        }
        return instance;
    }

    private static ILocalization? instance;

    public static void LoadLocalization()
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText(
                Path.Combine(GameSettings.PathToLocalizations,
                             GameSettings.Locale,
                             "Localization.json")
            )
        );
        instance = new Localization(dict ?? new Dictionary<string, string>());
    }
    public static void LoadLocalization(ILocalization localization) {
        instance = localization;
    }

    private readonly Dictionary<string, string> dictionary;
    private Localization(Dictionary<string, string> dictionary) {
        this.dictionary = dictionary;
    }

    public string this[string key] {
        get {
            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            }
            return key;
        }
    }
}
