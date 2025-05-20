using System.Text.Json;
using ComeForBrains.Exceptions;

namespace ComeForBrains.Core.Building.Items;

public class FromJsonItemBuilders : IItemsBuilders
{
    public FromJsonItemBuilders(string pathToFiles)
    {
        builders = new Dictionary<string, ItemBuilder>();

        armorBuilders =
            CreateBuilders<ArmorBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "Armor.json"))
            );
        AddToGeneral(armorBuilders);
        campElementsBuilders =
            CreateBuilders<CampElementBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "CampElement.json"))
            );
        AddToGeneral(campElementsBuilders);
        containersBuilders =
            CreateBuilders<ContainerBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "Container.json"))
            );
        AddToGeneral(containersBuilders);
        infectionKillersBuilders =
            CreateBuilders<InfectionKillerBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "InfectionKiller.json"))
            );
        AddToGeneral(infectionKillersBuilders);
        medicinesBuilders =
            CreateBuilders<MedicineBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "Medicine.json"))
            );
        AddToGeneral(medicinesBuilders);
        meleeWeaponsBuilders =
            CreateBuilders<MeleeWeaponBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "MeleeWeapon.json"))
            );
        AddToGeneral(meleeWeaponsBuilders);
        provisionsBuilders =
            CreateBuilders<ProvisionBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "Provision.json"))
            );
        AddToGeneral(provisionsBuilders);
        rangedWeaponsBuilders =
            CreateBuilders<RangedWeaponBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "RangedWeapon.json"))
            );
        AddToGeneral(rangedWeaponsBuilders);
        fuelBuilders =
            CreateBuilders<FuelBuilder>(
                new FromFileJsonProvider(Path.Combine(pathToFiles, "Fuel.json"))
            );
        AddToGeneral(rangedWeaponsBuilders);
    }

#pragma warning disable S107
    public FromJsonItemBuilders(
#pragma warning restore S107
        IJsonProvider armorBuildersJson,
        IJsonProvider campElementsBuildersJson,
        IJsonProvider containersBuildersJson,
        IJsonProvider infectionKillersBuildersJson,
        IJsonProvider medicinesBuildersJson,
        IJsonProvider meleeWeaponsBuildersJson,
        IJsonProvider provisionsBuildersJson,
        IJsonProvider rangedWeaponsBuildersJson,
        IJsonProvider fuelBuildersJson
    )
    {
        builders = new Dictionary<string, ItemBuilder>();

        armorBuilders =
            CreateBuilders<ArmorBuilder>(armorBuildersJson);
        AddToGeneral(armorBuilders);
        campElementsBuilders =
            CreateBuilders<CampElementBuilder>(campElementsBuildersJson);
        AddToGeneral(campElementsBuilders);
        containersBuilders =
            CreateBuilders<ContainerBuilder>(containersBuildersJson);
        AddToGeneral(containersBuilders);
        infectionKillersBuilders =
            CreateBuilders<InfectionKillerBuilder>(infectionKillersBuildersJson);
        AddToGeneral(infectionKillersBuilders);
        medicinesBuilders =
            CreateBuilders<MedicineBuilder>(medicinesBuildersJson);
        AddToGeneral(medicinesBuilders);
        meleeWeaponsBuilders =
            CreateBuilders<MeleeWeaponBuilder>(meleeWeaponsBuildersJson);
        AddToGeneral(meleeWeaponsBuilders);
        provisionsBuilders =
            CreateBuilders<ProvisionBuilder>(provisionsBuildersJson);
        AddToGeneral(provisionsBuilders);
        rangedWeaponsBuilders =
            CreateBuilders<RangedWeaponBuilder>(rangedWeaponsBuildersJson);
        AddToGeneral(rangedWeaponsBuilders);
        fuelBuilders =
            CreateBuilders<FuelBuilder>(fuelBuildersJson);
        AddToGeneral(fuelBuilders);
    }

    public ArmorBuilder GetArmorBuilder(string armorName)
    {
        return GetBuilder(armorName, armorBuilders);
    }

    public CampElementBuilder GetCampElementBuilder(string campElementName)
    {
        return GetBuilder(campElementName, campElementsBuilders);
    }

    public ContainerBuilder GetContainerBuilder(string containerName)
    {
        return GetBuilder(containerName, containersBuilders);
    }

    public InfectionKillerBuilder GetInfectionKillerBuilder(string infectionKillerName)
    {
        return GetBuilder(infectionKillerName, infectionKillersBuilders);
    }

    public MedicineBuilder GetMedicineBuilder(string medicineName)
    {
        return GetBuilder(medicineName, medicinesBuilders);
    }

    public MeleeWeaponBuilder GetMeleeWeaponBuilder(string meleeWeaponName)
    {
        return GetBuilder(meleeWeaponName, meleeWeaponsBuilders);
    }

    public ProvisionBuilder GetProvisionBuilder(string provisionName)
    {
        return GetBuilder(provisionName, provisionsBuilders);
    }

    public RangedWeaponBuilder GetRangedWeaponBuilder(string rangedWeaponName)
    {
        return GetBuilder(rangedWeaponName, rangedWeaponsBuilders);
    }

    public FuelBuilder GetFuelBuilder(string fuelName)
    {
        return GetBuilder(fuelName, fuelBuilders);
    }

    public ItemBuilder GetBuilder(string name)
    {
        return GetBuilder(name, builders);
    }


    private static T GetBuilder<T>(
        string name,
        Dictionary<string, T> builders
    ) where T : ItemBuilder
    {
        if(!builders.TryGetValue(name, out var builder))
            throw new ItemBuilderNotFoundException(name);
        return (T)builder.Copy();
    }

    private static Dictionary<string, T>
    CreateBuilders<T>(IJsonProvider itemBuildersJson)
        where T : ItemBuilder
    {
        var itemBuilders =
            JsonSerializer.Deserialize<Dictionary<string, T>>(
                itemBuildersJson.GetJson()
            );

        if (itemBuilders == null)
            throw new ArgumentException($"Item Builder from '{itemBuildersJson.GetJson()}' is null");

        return itemBuilders;
    }
    private void AddToGeneral<T>(Dictionary<string, T> typifiedBuilders)
        where T : ItemBuilder
    {
        foreach (var builder in typifiedBuilders)
        {
            if (!builders.ContainsKey(builder.Key))
                builders.Add(builder.Key, builder.Value);
        }
    }

    private readonly
    Dictionary<string, ArmorBuilder> armorBuilders;
    private readonly
    Dictionary<string, CampElementBuilder> campElementsBuilders;
    private readonly
    Dictionary<string, ContainerBuilder> containersBuilders;
    private readonly
    Dictionary<string, InfectionKillerBuilder> infectionKillersBuilders;
    private readonly
    Dictionary<string, MedicineBuilder> medicinesBuilders;
    private readonly
    Dictionary<string, MeleeWeaponBuilder> meleeWeaponsBuilders;
    private readonly
    Dictionary<string, ProvisionBuilder> provisionsBuilders;
    private readonly
    Dictionary<string, RangedWeaponBuilder> rangedWeaponsBuilders;
    private readonly
    Dictionary<string, FuelBuilder> fuelBuilders;

    private readonly Dictionary<string, ItemBuilder> builders;
}
