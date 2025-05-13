using ComeForBrains.Core.Building;
using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests.Building;

public class JsonFilesSettlementBuilderTests
{
    private readonly ISettlementBuilder builder
        = new JsonFilesSettlementBuilder(
            new DummySettlementJsonProvider(),
            new Dictionary<string, IMapBuilder>
            {
                {
                    "Mill",
                    new TextFileMapBuilder(
                        new DummyMapDataProvider(),
                        new DummyTileDescriptorJsonProvider()
                    )
                },
                {
                    "Village",
                    new TextFileMapBuilder(
                        new DummyVillageProvider(),
                        new DummyTileDescriptorJsonProvider()
                    )
                }
            },
            new Dictionary<string, IJsonProvider>
            {
                {"Mill", new DummyLocationJsonProvider().LocationProvider},
                {"Village", new DummyVillageProvider()}
            },
            new Dictionary<string, IJsonProvider>
            {
                {"Mill", new DummyLocationJsonProvider().ItemsProvider},
                {"Village", new FromTextJsonProvider("{}")}
            },
            new FromJsonItemBuilders(
                new DummyArmorJsonProvider(),
                new DummyCampElementJsonProvider(),
                new DummyContainerJsonProvider(),
                new DummyInfectionKillerJsonProvider(),
                new DummyMedicineJsonProvider(),
                new DummyMeleeWeaponJsonProvider(),
                new DummyProvosionJsonProvider(),
                new DummyRangedWeaponJsonProvider()
            )
        );
    private Settlement settlement = null!;
    
    [SetUp]
    public void Setup()
    {
        settlement = new Settlement(builder);
    }

    [Test]
    public void Building_BuildSettlement_NameIsCorrect()
    {
        Assert.That(settlement.Name, Is.EqualTo("Borshevka"));
    }
    [Test]
    public void Building_BuildSettlement_ConnectionsSetupCorrectly()
    {
        Assert.That(settlement.HasConnection("Kvasovo"), Is.True);
        Assert.That(settlement.GetDistance("Kvasovo"), Is.EqualTo(10));
    }
    [Test]
    public void Building_BuildSettlement_LocationsIsBuilded()
    {
        Assert.That(settlement.GetLocation("Mill").Name, Is.EqualTo("Mill"));
        Assert.That(settlement.GetLocation("Village").Name, Is.EqualTo("Village"));
    }
}
