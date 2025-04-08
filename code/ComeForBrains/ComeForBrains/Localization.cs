using System.Text.Json;

namespace ComeForBrains;

public class Localization
{
    public static Localization GetInstance() {
        if (instance is null) {
            throw new InvalidOperationException(
                "Localization is not initialized"
            );
        }
        return instance;
    }

    private static Localization? instance;

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
