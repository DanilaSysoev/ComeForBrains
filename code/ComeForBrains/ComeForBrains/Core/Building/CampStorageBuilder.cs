using ComeForBrains.Core.Building.Items;
using ComeForBrains.Core.GameWorld;
using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Building;

public class CampStorageBuilder
{
    public CampStorageBuilder(IJsonProvider itemsProvider)
    {
        this.itemsProvider = itemsProvider;
    }

    public void PlaceItems(Camp camp, IItemsBuilders itemsBuilders)
    {
        var locationDescriptor =
            new ItemsStorageDescriptorBuilder(itemsProvider).Build();
        BuildArmors(locationDescriptor, camp, itemsBuilders);
        BuildCampElements(locationDescriptor, camp, itemsBuilders);
        BuildInfectionKillers(locationDescriptor, camp, itemsBuilders);
        BuildMedicines(locationDescriptor, camp, itemsBuilders);
        BuildProvisions(locationDescriptor, camp, itemsBuilders);
        BuildRangedWeapons(locationDescriptor, camp, itemsBuilders);
        BuildMeleeWeapons(locationDescriptor, camp, itemsBuilders);
        BuildContainers(locationDescriptor, camp, itemsBuilders);
        BuildFuels(locationDescriptor, camp, itemsBuilders);
    }

    private static void BuildArmors(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(armor);
        }
    }

    private static void BuildCampElements(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(campElement);
        }
    }

    private static void BuildInfectionKillers(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(infectionKiller);
        }
    }

    private static void BuildMedicines(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(medicine);
        }
    }

    private static void BuildProvisions(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(provision);
        }
    }

    private static void BuildRangedWeapons(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(rangedWeapon);
        }
    }

    private static void BuildMeleeWeapons(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(meleeWeapon);
        }
    }

    private static void BuildFuels(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(fuel);
        }
    }

    private static void BuildContainers(
        ItemsStorageDescriptor locationDescriptor,
        Camp camp,
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
            camp.AddToStorage(container);
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

    private readonly IJsonProvider itemsProvider;
}
