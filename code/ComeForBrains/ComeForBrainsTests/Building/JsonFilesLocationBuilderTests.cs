using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.GameWorld;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class JsonFilesLocationBuilderTests : Tests
{
    private IMapBuilder mapBuilder = null!;
    private ILocationBuilder locationBuilder = null!;


    [SetUp]
    public void Setup()
    {
        mapBuilder = new TextFileMapBuilder(
            new DummyMapDataProvider(),
            new DummyTileDescriptorJsonProvider()
        );
        locationBuilder = new JsonFilesLocationBuilder(
            mapBuilder,
            new DummyLocationJsonProvider()
        );
    }

    [Test]
    public void BuildName_BuildingName_ReturnCorrectName()
    {
        Assert.That(locationBuilder.BuildName(), Is.EqualTo("Mill"));
    }
    [Test]
    public void BuildMap_BuildingMap_MapWidthIsCorrect()    
    {
        var map = locationBuilder.BuildMap();
        Assert.That(map.Width, Is.EqualTo(3));
    }
    [Test]
    public void BuildMap_BuildingMap_MapHeightIsCorrect()    
    {
        var map = locationBuilder.BuildMap();
        Assert.That(map.Height, Is.EqualTo(4));
    }
    [Test]
    public void BuildMap_BuildingMap_TilesIsCorrect()
    {
        var map = locationBuilder.BuildMap();
        AssertTile(map[0, 0], "Grass", "GrassDescription", 0.9);
        AssertTile(map[0, 1], "BrickWall", "BrickWallDescription", 0);
        AssertTile(map[0, 2], "Grass", "GrassDescription", 0.9);
        
        AssertTile(map[1, 0], "BrickWall", "BrickWallDescription", 0);
        AssertTile(map[1, 1], "Ground", "GroundDescription", 1.0);
        AssertTile(map[1, 2], "BrickWall", "BrickWallDescription", 0);
        
        AssertTile(map[2, 0], "BrickWall", "BrickWallDescription", 0);
        AssertTile(map[2, 1], "Ground", "GroundDescription", 1.0);
        AssertTile(map[2, 2], "BrickWall", "BrickWallDescription", 0);

        AssertTile(map[3, 0], "Grass", "GrassDescription", 0.9);
        AssertTile(map[3, 1], "BrickWall", "BrickWallDescription", 0);
        AssertTile(map[3, 2], "Grass", "GrassDescription", 0.9);
    }

    private static void AssertTile(
        Tile tile, string name, string description, double passability
    )
    {
        Assert.That(tile.Name, Is.EqualTo(name));
        Assert.That(tile.Description, Is.EqualTo(description));
        Assert.That(tile.Passability, Is.EqualTo(passability).Within(0.00001));
    }
}
