using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.GameWorld;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class TextFileMapBuilderTests : Tests
{
    private IMapBuilder mapBuilder = null!;

    [SetUp]
    public void Setup()
    {
        mapBuilder = new TextFileMapBuilder(
            new DummyMapDataProvider(),
            new DummyTileDescriptorJsonProvider()
        );
    }

    [Test]
    public void Build_BuildingMap_HasNoErrors()
    {
        Assert.DoesNotThrow(() => mapBuilder.Build());
    }
    [Test]
    public void Build_BuildingMap_MapWidthIsCorrect()
    {
        mapBuilder.Build();
        Assert.That(mapBuilder.GetWidth(), Is.EqualTo(3));
    }
    [Test]
    public void Build_BuildingMap_MapHeightIsCorrect()
    {
        mapBuilder.Build();
        Assert.That(mapBuilder.GetHeight(), Is.EqualTo(4));
    }
    [Test]
    public void Build_BuildingMap_TilesIsCorrect()
    {
        mapBuilder.Build();
        AssertTile(mapBuilder.GetTile(0, 0), "Grass", "GrassDescription", 0.9);
        AssertTile(mapBuilder.GetTile(0, 1), "BrickWall", "BrickWallDescription", 0);
        AssertTile(mapBuilder.GetTile(0, 2), "Grass", "GrassDescription", 0.9);
        
        AssertTile(mapBuilder.GetTile(1, 0), "BrickWall", "BrickWallDescription", 0);
        AssertTile(mapBuilder.GetTile(1, 1), "Ground", "GroundDescription", 1.0);
        AssertTile(mapBuilder.GetTile(1, 2), "BrickWall", "BrickWallDescription", 0);
        
        AssertTile(mapBuilder.GetTile(2, 0), "BrickWall", "BrickWallDescription", 0);
        AssertTile(mapBuilder.GetTile(2, 1), "Ground", "GroundDescription", 1.0);
        AssertTile(mapBuilder.GetTile(2, 2), "BrickWall", "BrickWallDescription", 0);

        AssertTile(mapBuilder.GetTile(3, 0), "Grass", "GrassDescription", 0.9);
        AssertTile(mapBuilder.GetTile(3, 1), "BrickWall", "BrickWallDescription", 0);
        AssertTile(mapBuilder.GetTile(3, 2), "Grass", "GrassDescription", 0.9);
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
