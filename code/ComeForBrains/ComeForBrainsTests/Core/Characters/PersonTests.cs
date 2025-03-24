using ComeForBrains.Core.Building;
using ComeForBrains.Core.Characters;

namespace ComeForBrainsTests.Core.Characters;

public class PersonTests
{
    private DefaultAttributesBuilder builder = null!;
    private Person person = null!;

    [SetUp]
    public void Setup()
    {
        builder = new("name", 1000, 1000, 1000, 1000, 1000);
        person = new Person(builder);
    }

    [Test]
    public void Features_NewPerson_HasNoPenalties()
    {
        Assert.That(person.Strength, Is.EqualTo(1000));
        Assert.That(person.Dexterity, Is.EqualTo(1000));
        Assert.That(person.DistanceAccuracy, Is.EqualTo(1000));
        Assert.That(person.MeleeFight, Is.EqualTo(1000));
    }

    [Test]
    public void Features_HasHealthPenalty_ValuesCalculatedCorrect()
    {
        var penalty = person.Health.Penalties.First();
        person.Health.Value = (penalty.ToExclusive + penalty.FromInclusive) / 2.0;

        Assert.That(person.Strength, Is.EqualTo(1000 * (1.0 - penalty.Value)).Within(0.00001));
        Assert.That(person.Dexterity, Is.EqualTo(1000 * (1.0 - penalty.Value)).Within(0.00001));
        Assert.That(person.DistanceAccuracy, Is.EqualTo(1000 * (1.0 - penalty.Value)).Within(0.00001));
        Assert.That(person.MeleeFight, Is.EqualTo(1000 * (1.0 - penalty.Value)).Within(0.00001));
        Assert.That(person.Speed, Is.EqualTo((1000 + person.DexterityModifier * 10 - person.OverloadModifier * 20) * (1.0 - penalty.Value)).Within(0.00001));
    }

    [Test]
    public void Features_HasTwoPenalties_ValuesCalculatedCorrect()
    {
        var penalty_1 = person.Health.Penalties.ToList()[1];
        person.Health.Value = (penalty_1.ToExclusive + penalty_1.FromInclusive) / 2.0;

        var penalty_2 = person.Thirst.Penalties.ToList()[0];
        person.Thirst.Value = (penalty_2.ToExclusive + penalty_2.FromInclusive) / 2.0;

        Assert.That(person.Strength, Is.EqualTo(1000 * (1.0 - penalty_1.Value) * (1.0 - penalty_2.Value)).Within(0.00001));
        Assert.That(person.Dexterity, Is.EqualTo(1000 * (1.0 - penalty_1.Value) * (1.0 - penalty_2.Value)).Within(0.00001));
        Assert.That(person.DistanceAccuracy, Is.EqualTo(1000 * (1.0 - penalty_1.Value) * (1.0 - penalty_2.Value)).Within(0.00001));
        Assert.That(person.MeleeFight, Is.EqualTo(1000 * (1.0 - penalty_1!.Value) * (1.0 - penalty_2.Value)).Within(0.00001));
    }
}
