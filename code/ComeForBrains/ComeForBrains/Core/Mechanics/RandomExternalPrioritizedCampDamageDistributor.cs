using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics.Base;
using ComeForBrains.Service;

namespace ComeForBrains.Core.Mechanics;

public class RandomExternalPrioritizedCampDamageDistributor
    : ICampDamageDistributor
{
    public RandomExternalPrioritizedCampDamageDistributor(
        GameContext gameContext, double totalDamage
    )
    {
        CalculateElementsDamage(gameContext, totalDamage);
    }

    public double CalculateDamage(CampElement campElement)
    {
        if (damageByElementIds.ContainsKey(campElement.Id))
            return damageByElementIds[campElement.Id];
        return 0;
    }

    private void CalculateElementsDamage(
        GameContext gameContext, double totalDamage
    )
    {
        var sumStrengthOfExternal =
            gameContext.Camp.ExternalCampElements.Sum(ce => ce.Strength);

        var damageOfExternal = Math.Min(totalDamage, sumStrengthOfExternal);
        var damageOfInternal = totalDamage - damageOfExternal;
        RandomDistributeDamage(
            damageOfExternal, gameContext.Camp.ExternalCampElements
        );
        if (damageOfInternal > 0.00001)
        {
            RandomDistributeDamage(
                damageOfInternal, gameContext.Camp.InternalCampElements
            );
        }
    }

    private void RandomDistributeDamage(
        double damage, IEnumerable<CampElement> campElements
    )
    {
        var stepCount = GameSettings.NemberOfIterationsInRandomDistributor;
        var elementsList = campElements.ToList();
        var elementsStrengths =
            elementsList.Select(ce => ce.Strength).ToList();
        for (int i = 0; i < stepCount; ++i)
            DamageStep(damage / stepCount, elementsStrengths, elementsList);
    }

    private void DamageStep(
        double damage, List<double> strengths, List<CampElement> elements
    )
    {
        while (damage > 0.00001)
        {
            var sumStrengthOfExternal = strengths.Sum();
            double point =
                RandomProvider.Instance.NextDouble(sumStrengthOfExternal);

            int damagedIndex = SelectDamagedElement(point, strengths);
            double elemDamage = Math.Min(strengths[damagedIndex], damage);
            UpdateElementDamage(elements[damagedIndex], elemDamage);
            strengths[damagedIndex] -= elemDamage;
            damage -= elemDamage;
        }
    }

    private static int SelectDamagedElement(
        double point, List<double> strengths
    )
    {
        double curSum = 0;
        for (int i = 0; i < strengths.Count; i++)
        {
            double campStrendth = strengths[i];
            curSum += campStrendth;
            if (point <= curSum)
                return i;
        }
        return strengths.Count - 1;
    }

    private void UpdateElementDamage(
        CampElement campElement, double elemDamage
    )
    {
        if(!damageByElementIds.ContainsKey(campElement.Id))
            damageByElementIds.Add(campElement.Id, 0);
        damageByElementIds[campElement.Id] += elemDamage;
    }

    private readonly Dictionary<ulong, double> damageByElementIds = new();
}
