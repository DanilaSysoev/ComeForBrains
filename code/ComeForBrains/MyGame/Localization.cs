namespace ComeForBrains;

public class Localization
{
    public static Localization GetInstance() {
        return instance;
    }

    private static Localization instance = LoadLocalization();

    private static Localization LoadLocalization()
    {
        return new Localization(new Dictionary<string, string>() {
            {"Come for brains", "Приходите за мозгами"},
        });
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
            return "ERROR! Can't find key: " + key;
        }
    }
}
