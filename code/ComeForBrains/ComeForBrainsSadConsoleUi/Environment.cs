using System.Text.Json;
using ComeForBrains.Core;
using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Localizations;
using ComeForBrains.Service;

namespace ComeForBrainsSadConsoleUi;

public class Environment
{
    public World World { get; private set; } = null!;
    public GameContext Context { get; private set; } = null!;

    public static void Create()
    {
        if(ExistSaveWorld())
        {
            CreateIdProvider();
            string pathToItemsDescriptors = Path.Combine("Data", "Items");
            string worldName = ExtractWorldName();
            IWorldBuilder worldBuilder = new JsonFilesWorldBuilder(
                Path.Combine(WorldsDirectory, worldName), pathToItemsDescriptors
            );
            IGameContextBuilder contextBuilder = new GameContextBuilder(
                new BaseJsonPersonBuilder(
                    new FromFileJsonProvider(
                        Path.Combine(WorldsDirectory, worldName, "Person.json")
                    )
                ),
                new BaseJsonCampBuilder(
                    new FromFileJsonProvider(
                        Path.Combine(WorldsDirectory, worldName, "Camp.json")
                    )
                ),
                ExtractDayNumber(),
                ExtractDayStageName(),
                Path.Combine(WorldsDirectory, worldName, "Storage.json"),
                pathToItemsDescriptors
            );

            Environment environment = new()
            {
                World = new World(worldBuilder),
                Context = new GameContext(contextBuilder),
            };
            Instance = environment;
        }
        else
        {
            throw new InvalidOperationException(
                "Процедурный генератор мира пока не реализован"
            );
        }
    }

    public static Environment Instance { get; private set; } = null!;
    public static ILocalization L { get; private set; }


    private static void CreateIdProvider()
    {
        IdProvider.Initialize(new IncrementalIdProvider());
    }

    private static uint ExtractDayNumber()
    {
        return uint.Parse(JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText(SavedWorldPath)
        )!["dayNumber"]);
    }

    private static string ExtractDayStageName()
    {
        return JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText(SavedWorldPath)
        )!["dayStage"];
    }

    private static string ExtractWorldName()
    {
        return JsonSerializer.Deserialize<Dictionary<string, string>>(
            File.ReadAllText(SavedWorldPath)
        )!["name"];
    }

    private static bool ExistSaveWorld()
    {
        return File.Exists(SavedWorldPath);
    }

    static Environment()
    {
        Localization.LoadLocalization();            
        L = Localization.GetInstance();
    }

    private const string SavedWorldPath = "saved_world.json";
    private const string WorldsDirectory = "Worlds";
}
