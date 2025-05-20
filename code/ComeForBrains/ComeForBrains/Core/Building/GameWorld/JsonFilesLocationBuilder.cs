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
        itemsStorageDataProvider = new FromFileJsonProvider(
            Path.Combine(pathToFiles, "Items.json")
        );
    }
    public JsonFilesLocationBuilder(
        IMapBuilder mapBuilder,
        IJsonProvider locationDataProvider,
        IJsonProvider itemsStorageDataProvider
    )
    {
        this.mapBuilder = mapBuilder;
        this.locationDataProvider = locationDataProvider;
        this.itemsStorageDataProvider = itemsStorageDataProvider;
    }

    public Map BuildMap()
    {
        return new Map(mapBuilder);
    }

    public string BuildName()
    {
        return JsonSerializer.Deserialize<Dictionary<string, string>>(
            locationDataProvider.GetJson()
        )!["Name"];
    }

    public void PlaceItems(Map map, IItemsBuilders itemsBuilders)
    {
        var locationDescriptor =
            new ItemsStorageDescriptorBuilder(itemsStorageDataProvider).Build();
        BuildArmors(locationDescriptor, map, itemsBuilders);
        BuildCampElements(locationDescriptor, map, itemsBuilders);
        BuildInfectionKillers(locationDescriptor, map, itemsBuilders);
        BuildMedicines(locationDescriptor, map, itemsBuilders);
        BuildProvisions(locationDescriptor, map, itemsBuilders);
        BuildRangedWeapons(locationDescriptor, map, itemsBuilders);
        BuildMeleeWeapons(locationDescriptor, map, itemsBuilders);
        BuildContainers(locationDescriptor, map, itemsBuilders);
        BuildFuels(locationDescriptor, map, itemsBuilders);
    }

    private static void BuildArmors(
        ItemsStorageDescriptor locationDescriptor,
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
        ItemsStorageDescriptor locationDescriptor,
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
            CorrectionStrengthProperty(descriptor, builder);

            CampElement campElement = new(builder);
            map[descriptor.Line, descriptor.Column].Place(campElement);
        }
    }

    private static void BuildInfectionKillers(
        ItemsStorageDescriptor locationDescriptor,
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
        ItemsStorageDescriptor locationDescriptor,
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
        ItemsStorageDescriptor locationDescriptor,
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
        ItemsStorageDescriptor locationDescriptor,
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
        ItemsStorageDescriptor locationDescriptor,
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

    private static void BuildFuels(
        ItemsStorageDescriptor locationDescriptor,
        Map map,
        IItemsBuilders itemsBuilders
    )
    {
        foreach(var descriptor in locationDescriptor.Fuels)
        {
            var builder =
                itemsBuilders.GetFuelBuilder(descriptor.Name);
            CorrectionBaseProperties(descriptor, builder);
            CorrectionItemProperty(descriptor, builder, "EmptyWeight");
            CorrectionItemProperty(descriptor, builder, "Volume");

            Fuel fuel = new(builder);
            map[descriptor.Line, descriptor.Column].Place(fuel);
        }
    }

    private static void BuildContainers(
        ItemsStorageDescriptor locationDescriptor,
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

    private static void CorrectionStrengthProperty(
        CampElementDescriptor descriptor,
        CampElementBuilder builder
    )
    {
        var value = descriptor.Strength;
        if (value is null)
            builder.Strength = builder.MaxStrength;
        else
            builder.Strength = value.Value;
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

    private readonly IMapBuilder mapBuilder;
    private readonly IJsonProvider locationDataProvider;
    private readonly IJsonProvider itemsStorageDataProvider;
}
