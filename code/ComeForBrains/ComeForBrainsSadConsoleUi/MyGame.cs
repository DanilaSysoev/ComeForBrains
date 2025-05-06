using System.Text.Json;
using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Localizations;
using ComeForBrainsSadConsoleUi.Screens;
using SadConsole.Configuration;

namespace ComeForBrainsSadConsoleUi;

public static class MyGame
{
    static MyGame()
    {
        Localization.LoadLocalization();
        L = Localization.GetInstance();
    }

    public static ILocalization L { get; private set; }
    public static IWorldBuilder WorldBuilder { get; private set; } = null!;
    public static IGameContextBuilder ContextBuilder { get; private set; } = null!;

    public static void Main()
    {
        Settings.WindowTitle = "Come for brains!";

        Builder configuration = new Builder()
            .SetScreenSize(SadUiGameSettings.GameWidth,
                           SadUiGameSettings.GameHeight)
            .SetStartingScreen<MainMenuScreen>()
            .IsStartingScreenFocused(true)
            .OnStart((_, _) => CreateWorldBuilder())
            ;

        Game.Create(configuration);
        Game.Instance.Run();
        Game.Instance.Dispose();
    }

    public static void CreateWorldBuilder()
    {
        if(ExistSaveWorld())
        {
            string worldName = ExtractWorldName();
            WorldBuilder = new JsonFilesWorldBuilder(
                Path.Combine("Worlds", worldName), Path.Combine("Data", "Items")
            );
            ContextBuilder = new GameContextBuilder(
                new BaseJsonPersonBuilder(
                    new FromFileJsonProvider(
                        Path.Combine("Worlds", worldName, "Person.json")
                    )
                ),
                new BaseJsonCampBuilder(
                    new FromFileJsonProvider(
                        Path.Combine("Worlds", worldName, "Camp.json")
                    )
                ),
                ExtractDayNumber()
            );
        }
        else
        {
            throw new InvalidOperationException(
                "Процедурный генератор мира пока не реализован"
            );
        }
    }

    private static uint ExtractDayNumber()
    {
        return uint.Parse(JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText("saved_world.json")
        )!["dayNumber"]);
    }

    private static string ExtractWorldName()
    {
        return JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText("saved_world.json")
        )!["name"];
    }

    private static bool ExistSaveWorld()
    {
        return File.Exists("saved_world.json");
    }
}
