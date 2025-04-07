using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Mechanics.Base;

public interface ICampDamageDistributor
{
    double CalculateDamage(CampElement campElement);
}
