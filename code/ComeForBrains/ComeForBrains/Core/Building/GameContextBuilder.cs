using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building;

public class GameContextBuilder : IGameContextBuilder
{
    public GameContextBuilder(
        IPersonBuilder personBuilder,
        ICampBuilder campBuilder,
        CarBuilder carBuilder,
        uint dayNumber,
        string dayStageName,
        string pathToStorageItems,
        string pathToItemsDescriptorsFiles
    )
    {
        DayNumber = dayNumber;
        this.personBuilder = personBuilder;
        this.campBuilder = campBuilder;
        this.carBuilder = carBuilder;
        DayStageName = dayStageName;
        this.pathToStorageItems = pathToStorageItems;
        this.pathToItemsDescriptorsFiles = pathToItemsDescriptorsFiles;
    }

    public uint DayNumber { get; set; }
    public string DayStageName { get; set; }
    public DayStage DayStage => Enum.Parse<DayStage>(DayStageName);

    public Camp BuildCamp()
    {
        return new Camp(
            campBuilder,
            new CampStorageBuilder(
                new FromFileJsonProvider(
                    pathToStorageItems
                )
            ),
            new FromJsonItemBuilders(
                pathToItemsDescriptorsFiles
            )
        );
    }

    public Person BuildPerson()
    {
        return new Person(personBuilder);
    }

    public Car BuildCar()
    {
        return new Car(carBuilder);
    }

    private readonly IPersonBuilder personBuilder;
    private readonly ICampBuilder campBuilder;
    private readonly CarBuilder carBuilder;
    private readonly string pathToItemsDescriptorsFiles;
    private readonly string pathToStorageItems;
}
