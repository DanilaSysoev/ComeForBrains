using System.Text.Json;
using ComeForBrains.Core.Building.Characters;
using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building;

public class BaseJsonPersonBuilder : IPersonBuilder
{
    public BaseJsonPersonBuilder(IJsonProvider jsonProvider)
    {
        personDescriptor =
            JsonSerializer.Deserialize<PersonDescriptor>(
                jsonProvider.GetJson()
            )!;
    }

    public double GetBaseInfectionChance()
    {
        return personDescriptor.BaseInfectionChance;
    }

    public double GetDexterity()
    {
        return personDescriptor.Dexterity;
    }

    public double GetPhysique()
    {
        return personDescriptor.Physique;
    }

    public double GetDistanceAccuracy()
    {
        return personDescriptor.DistanceAccuracy;
    }

    public PersonAttribute GetEnergy()
    {
        return new PersonAttribute(
            personDescriptor.Energy.MinValue,
            personDescriptor.Energy.MaxValue,
            personDescriptor.Energy.Value,
            personDescriptor.Energy.Penalties
        );
    }

    public PersonAttribute GetHealth()
    {
        return new PersonAttribute(
            personDescriptor.Health.MinValue,
            personDescriptor.Health.MaxValue,
            personDescriptor.Health.Value,
            personDescriptor.Health.Penalties
        );
    }

    public double GetMeleeFight()
    {
        return personDescriptor.MeleeFight;
    }

    public string GetName()
    {
        return personDescriptor.Name;
    }

    public PersonAttribute GetSatiety()
    {
        return new PersonAttribute(
            personDescriptor.Satiety.MinValue,
            personDescriptor.Satiety.MaxValue,
            personDescriptor.Satiety.Value,
            personDescriptor.Satiety.Penalties
        );
    }

    public double GetSpeed()
    {
        return personDescriptor.Speed;
    }

    public double GetStrength()
    {
        return personDescriptor.Strength;
    }

    public PersonAttribute GetThirst()
    {
        return new PersonAttribute(
            personDescriptor.Thirst.MinValue,
            personDescriptor.Thirst.MaxValue,
            personDescriptor.Thirst.Value,
            personDescriptor.Thirst.Penalties
        );
    }


    private sealed class PersonAttributeDescriptor
    {
        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 0;
        public double Value { get; set; } = 0;

        public List<AttributePenalty> Penalties { get; set; } = new();
    }

    private sealed class PersonDescriptor
    {
        public string Name { get; set; } = "";
        public PersonAttributeDescriptor Energy { get; set; } = new();
        public PersonAttributeDescriptor Health { get; set; } = new();
        public PersonAttributeDescriptor Satiety { get; set; } = new();
        public PersonAttributeDescriptor Thirst { get; set; } = new();
        public double BaseInfectionChance { get; set; } = 0;
        public double Strength { get; set; } = 0;
        public double Dexterity { get; set; } = 0;
        public double Physique { get; set; } = 0;
        public double DistanceAccuracy { get; set; } = 0;
        public double MeleeFight { get; set; } = 0;
        public double Speed { get; set; } = 0;
    }

    private readonly PersonDescriptor personDescriptor;
}
