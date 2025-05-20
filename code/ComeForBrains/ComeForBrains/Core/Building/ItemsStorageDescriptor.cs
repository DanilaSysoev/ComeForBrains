namespace ComeForBrains.Core.Building;


internal class ItemDescriptor
{
    public string Name { get; set; } = "";
    public int[]? Position { get; set; } = [0, 0];
    public double? Weight { get; set; }
    public double? PassabilityPenalty { get; set; }

    public int Line => Position is null ? -1 : Position[0];
    public int Column => Position is null ? -1 : Position[1];
}

internal sealed class ArmorDescriptor : ItemDescriptor
{
    public double? Thikness { get; set; }
    public double? InfectionModifier { get; set; }
    public double? ArmorValue { get; set; }
    public double? EnergyConsumptionModifier { get; set; }
}

internal sealed class CampElementDescriptor : ItemDescriptor
{
    public double? FortificationValue { get; set; }
    public double? ComfortValue { get; set; }
    public double? MaxStrength { get; set; }
    public double? Strength { get; set; } = null;
}

internal sealed class InfectionKillerDescriptor : ItemDescriptor
{
    public double? SuccessChance { get; set; }
    public double? HealthDamage { get; set; }
    public double? EffectiveTime { get; set; }
}

internal sealed class MedicineDescriptor : ItemDescriptor
{
    public double? HealingPower { get; set; }
    public int? Count { get; set; }
}

internal sealed class ProvisionDescriptor : ItemDescriptor
{
    public double? SatietyPower { get; set; }
    public double? ThirstPower { get; set; }
    public double? EnergyPower { get; set; }
}

internal class WeaponDescriptor : ItemDescriptor
{
    public double? BaseDamage { get; set; }
    public double? InstantKillChance { get; set; }
    public double? BaseAccuracy { get; set; }
    public double? EnergyConsumptionModifier { get; set; }
    public double? MinEffectiveDistance { get; set; }
    public double? MaxEffectiveDistance { get; set; }
}

internal sealed class RangedWeaponDescriptor : WeaponDescriptor
{
    public double? NoiseDistance { get; set; }
}

internal sealed class ContainerDescriptor : ItemDescriptor
{
    public string[] Content { get; set; } = Array.Empty<string>();
}

internal class FuelDescriptor : ItemDescriptor
{
    public double? Volume { get; set; }
    public double? EmptyWeight { get; set; }
}


internal class ItemsStorageDescriptor
{
    public List<ArmorDescriptor> Armors { get; set; } = new();
    public List<CampElementDescriptor> CampElements { get; set; } = new();
    public List<InfectionKillerDescriptor> InfectionKillers { get; set; } = new();
    public List<MedicineDescriptor> Medicines { get; set; } = new();
    public List<ProvisionDescriptor> Provisions { get; set; } = new();
    public List<WeaponDescriptor> MeleeWeapons { get; set; } = new();
    public List<RangedWeaponDescriptor> RangedWeapons { get; set; } = new();
    public List<ContainerDescriptor> Containers { get; set; } = new();
    public List<FuelDescriptor> Fuels { get; set; } = new();
}
