using System.Text.Json;
using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building.GameWorld;

public class JsonFilesLocationBuilder : ILocationBuilder
{
    public JsonFilesLocationBuilder(string pathToFiles)
    {
        mapBuilder = new TextFileMapBuilder(Path.Combine(pathToFiles, "Map"));
        locationDataProvider = new FromFileJsonProvider(
            Path.Combine(pathToFiles, "Location.json")
        );
    }
    public JsonFilesLocationBuilder(
        IMapBuilder mapBuilder,
        IJsonProvider locationDataProvider
    )
    {
        this.mapBuilder = mapBuilder;
        this.locationDataProvider = locationDataProvider;
    }

    public Map BuildMap()
    {
        return new Map(mapBuilder);
    }

    public string BuildName()
    {
        LocationDescriptor locationDescriptor = BuildDescriptor();
        return locationDescriptor.Name;
    }

    private LocationDescriptor BuildDescriptor()
    {
        var locationDescriptor = JsonSerializer.Deserialize<LocationDescriptor>(
            locationDataProvider.GetJson()
        );
        if (locationDescriptor is null)
            throw new InvalidOperationException("No location descriptors found");
        return locationDescriptor;
    }

    public void PlaceItems(Map map, IItemsBuilders itemsBuilders)
    {
        var locationDescriptor = BuildDescriptor();
        BuildArmors(locationDescriptor, map, itemsBuilders);
        BuildCampElements(locationDescriptor, map, itemsBuilders);
        BuildInfectionKillers(locationDescriptor, map, itemsBuilders);
        BuildMedicines(locationDescriptor, map, itemsBuilders);
        BuildProvisions(locationDescriptor, map, itemsBuilders);
        BuildRangedWeapons(locationDescriptor, map, itemsBuilders);
        BuildMeleeWeapons(locationDescriptor, map, itemsBuilders);
        BuildContainers(locationDescriptor, map, itemsBuilders);
    }


    private static void BuildArmors(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.Armors)
        {
            var builder = itemsBuilders.GetArmorBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "ArmorValue");
            CorrectionItemProperty(descriptor, builder, "InfectionModifier");
            CorrectionItemProperty(
                descriptor, builder, "EnergyConsumptionModifier"
            );
            CorrectionItemProperty(descriptor, builder, "Thikness");

            Armor armor = new(builder);
            map[descriptor.Line, descriptor.Column].Place(armor);
        }
    }

    private static void BuildCampElements(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.CampElements)
        {
            var builder = itemsBuilders.GetCampElementBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "FortificationValue");
            CorrectionItemProperty(descriptor, builder, "ComfortValue");
            CorrectionItemProperty(descriptor, builder, "MaxStrength");
            CorrectionItemProperty(descriptor, builder, "Strength");

            CampElement campElement = new(builder);
            map[descriptor.Line, descriptor.Column].Place(campElement);
        }
    }

    private static void BuildInfectionKillers(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.InfectionKillers)
        {
            var builder =
                itemsBuilders.GetInfectionKillerBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "SuccessChance");
            CorrectionItemProperty(descriptor, builder, "HealthDamage");
            CorrectionItemProperty(descriptor, builder, "EffectiveTime");

            InfectionKiller infectionKiller = new(builder);
            map[descriptor.Line, descriptor.Column].Place(infectionKiller);
        }
    }

    private static void BuildMedicines(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.Medicines)
        {
            var builder =
                itemsBuilders.GetMedicineBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "HealingPower");
            CorrectionItemProperty(descriptor, builder, "Count");

            Medicine medicine = new(builder);
            map[descriptor.Line, descriptor.Column].Place(medicine);
        }
    }

    private static void BuildProvisions(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.Provisions)
        {
            var builder =
                itemsBuilders.GetProvisionBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "SatietyPower");
            CorrectionItemProperty(descriptor, builder, "ThirstPower");
            CorrectionItemProperty(descriptor, builder, "EnergyPower");

            Provision provision = new(builder);
            map[descriptor.Line, descriptor.Column].Place(provision);
        }
    }

    private static void BuildRangedWeapons(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.RangedWeapons)
        {
            var builder =
                itemsBuilders.GetRangedWeaponBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "BaseDamage");
            CorrectionItemProperty(descriptor, builder, "InstantKillChance");
            CorrectionItemProperty(descriptor, builder, "BaseAccuracy");
            CorrectionItemProperty(descriptor, builder, "EnergyConsumptionModifier");
            CorrectionItemProperty(descriptor, builder, "MinEffectiveDistance");
            CorrectionItemProperty(descriptor, builder, "MaxEffectiveDistance");
            CorrectionItemProperty(descriptor, builder, "NoiseDistance");

            RangedWeapon rangedWeapon = new(builder);
            map[descriptor.Line, descriptor.Column].Place(rangedWeapon);
        }
    }

    private static void BuildMeleeWeapons(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.MeleeWeapons)
        {
            var builder =
                itemsBuilders.GetMeleeWeaponBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "BaseDamage");
            CorrectionItemProperty(descriptor, builder, "InstantKillChance");
            CorrectionItemProperty(descriptor, builder, "BaseAccuracy");
            CorrectionItemProperty(descriptor, builder, "EnergyConsumptionModifier");
            CorrectionItemProperty(descriptor, builder, "MinEffectiveDistance");
            CorrectionItemProperty(descriptor, builder, "MaxEffectiveDistance");

            MeleeWeapon meleeWeapon = new(builder);
            map[descriptor.Line, descriptor.Column].Place(meleeWeapon);
        }
    }

    private static void BuildContainers(
        LocationDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.Containers)
        {
            var builder =
                itemsBuilders.GetContainerBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);

            Container container = new(builder);
            foreach(var itemName in descriptor.Content)
            {
                container.Add(
                    itemsBuilders.GetBuilder(itemName).Build()
                );
            }
            map[descriptor.Line, descriptor.Column].Place(container);
        }
    }

    private static void CorrectionItemProperty<TDescriptor, TBuilder>(
        TDescriptor descriptor,
        TBuilder builder,
        string propertyName
    )
    {
        if (descriptor!.GetType().GetProperty(propertyName) is null)
            return;
        var value = descriptor.GetType().GetProperty(propertyName)?.GetValue(
            descriptor
        );
        if (value is null)
            return;
        builder!.GetType().GetProperty(propertyName)?.SetValue(builder, value);
    }

    private static void CorrectionBaseProperties(
        ItemDescriptor descriptor, ItemBuilder builder
    )
    {
        CorrectionItemProperty(descriptor, builder, "PassabilityPenalty");
        CorrectionItemProperty(descriptor, builder, "Weight");
    }
#pragma warning disable S1144
    private class ItemDescriptor
    {
        public string Name { get; set; } = "";
        public int[] Position { get; set; } = [0, 0];
        public double? Weight { get; set; }
        public double? PassabilityPenalty { get; set; }

        public int Line => Position[0];
        public int Column => Position[1];
    }

    private sealed class ArmorDescriptor : ItemDescriptor
    {
        public double? Thikness { get; set; }
        public double? InfectionModifier { get; set; }
        public double? ArmorValue { get; set; }
        public double? EnergyConsumptionModifier { get; set; }
    }

    private sealed class CampElementDescriptor : ItemDescriptor
    {
        public double? FortificationValue { get; set; }
        public double? ComfortValue { get; set; }
        public double? MaxStrength { get; set; }
        public double? Strength { get; set; }
    }

    private sealed class InfectionKillerDescriptor : ItemDescriptor
    {
        public double? SuccessChance { get; set; }
        public double? HealthDamage { get; set; }
        public double? EffectiveTime { get; set; }
    }

    private sealed class MedicineDescriptor : ItemDescriptor
    {
        public double? HealingPower { get; set; }
        public int? Count { get; set; }
    }

    private sealed class ProvisionDescriptor : ItemDescriptor
    {
        public double? SatietyPower { get; set; }
        public double? ThirstPower { get; set; }
        public double? EnergyPower { get; set; }
    }

    private class WeaponDescriptor : ItemDescriptor
    {
        public double? BaseDamage { get; set; }
        public double? InstantKillChance { get; set; }
        public double? BaseAccuracy { get; set; }
        public double? EnergyConsumptionModifier { get; set; }
        public double? MinEffectiveDistance { get; set; }
        public double? MaxEffectiveDistance { get; set; }
    }

    private sealed class RangedWeaponDescriptor : WeaponDescriptor
    {
        public double? NoiseDistance { get; set; }
    }

    private sealed class ContainerDescriptor : ItemDescriptor
    {
        public string[] Content { get; set; } = Array.Empty<string>();
    }
#pragma warning restore S1144

    private sealed class LocationDescriptor
    {
        public string Name { get; set; } = "";
        public List<ArmorDescriptor> Armors { get; set; } = new();
        public List<CampElementDescriptor> CampElements { get; set; } = new();
        public List<InfectionKillerDescriptor> InfectionKillers { get; set; } = new();
        public List<MedicineDescriptor> Medicines { get; set; } = new();
        public List<ProvisionDescriptor> Provisions { get; set; } = new();
        public List<WeaponDescriptor> MeleeWeapons { get; set; } = new();
        public List<RangedWeaponDescriptor> RangedWeapons { get; set; } = new();
        public List<ContainerDescriptor> Containers { get; set; } = new();
    }

    private readonly IMapBuilder mapBuilder;
    private readonly IJsonProvider locationDataProvider;
}
