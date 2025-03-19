using ComeForBrains.Core;
using ComeForBrains.Core.Characters;
using ComeForBrains.Core.Items;
using ComeForBrains.Service;
using MyGameTests.Helpers;

namespace MyGameTests.Core.Items;

public class InfectionKillerTests
{
    private GameContext gameContext = null!;
    private Person person = null!;
    private InfectionKiller ic0 = null!;
    private InfectionKiller ic1 = null!;

    [SetUp]
    public void Setup()
    {
        RandomProvider.Initialize(new RangeSuccessRandom(0, 50));

        person = new Person(new DummyPersonBuilder());
        gameContext = new GameContext(person);
        ic0 = new InfectionKiller("ic0", "d0", 1, 1, 30, 20, 100);
        ic1 = new InfectionKiller("ic1", "d1", 1, 1, 80, 30, 10);

        person.Inventory.AddItem(ic0);
        person.Inventory.AddItem(ic1);

        person.Infect();
    }

    
}
