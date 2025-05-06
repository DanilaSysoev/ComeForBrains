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
        public double MinValue = 0;
        public double MaxValue = 0;
        public double Value = 0;

        public List<AttributePenalty> Penalties = new();
    }

    private sealed class PersonDescriptor
    {
        public string Name = "";
        public PersonAttributeDescriptor Energy = new();
        public PersonAttributeDescriptor Health = new();
        public PersonAttributeDescriptor Satiety = new();
        public PersonAttributeDescriptor Thirst = new();
        public double BaseInfectionChance = 0;
        public double Strength = 0;
        public double Dexterity = 0;
        public double DistanceAccuracy = 0;
        public double MeleeFight = 0;
        public double Speed = 0;
    }

    private readonly PersonDescriptor personDescriptor;
}
