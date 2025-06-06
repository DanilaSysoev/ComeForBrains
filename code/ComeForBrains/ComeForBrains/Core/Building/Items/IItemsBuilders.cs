namespace ComeForBrains.Core.Building.Items;

public interface IItemsBuilders
{
    ArmorBuilder GetArmorBuilder(string armorName);
    CampElementBuilder GetCampElementBuilder(string campElementName);
    InfectionKillerBuilder GetInfectionKillerBuilder(string infectionKillerName);
    ContainerBuilder GetContainerBuilder(string containerName);
    MedicineBuilder GetMedicineBuilder(string medicineName);
    ProvisionBuilder GetProvisionBuilder(string provisionName);
    MeleeWeaponBuilder GetMeleeWeaponBuilder(string meleeWeaponName);
    RangedWeaponBuilder GetRangedWeaponBuilder(string rangedWeaponName);
    FuelBuilder GetFuelBuilder(string fuelName);

    ItemBuilder GetBuilder(string name);
}
