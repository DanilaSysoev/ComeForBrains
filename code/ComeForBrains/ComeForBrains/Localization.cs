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
            {"Head", "Голова"},
            {"Face", "Лицо"},
            {"Neck", "Шея"},
            {"Shoulders", "Плечи"},
            {"Forearms", "Предплечья"},
            {"Wrists", "Запястья"},
            {"Chest", "Грудь"},
            {"Back", "Спина"},
            {"Stomach", "Живот"},
            {"Thighs", "Бедра"},
            {"Shins", "Голени"},
            {"Feet", "Стопы"}
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
            return key;
        }
    }
}
