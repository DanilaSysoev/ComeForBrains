using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.GameWorld;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class LoadingItemsTests : Tests
{
    private JsonFilesLocationBuilder locationBuilder = null!;

    [SetUp]
    public void Setup()
    {
        locationBuilder = new JsonFilesLocationBuilder(
            new TextFileMapBuilder(
                new AllItemsMapDataProvider(),
                new DummyTileDescriptorJsonProvider()
            ),
            new AllItemsLocationJsonProvider()
        );
    }

    [Test]
    public void Build_CallMethod_BuildWithoutErrors()
    {
        Assert.DoesNotThrow(() => new Location(locationBuilder));
    }

    // TODO Дописать тесты!
}
