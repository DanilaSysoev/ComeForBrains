using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Mechanics.Base;

public interface ICampDestructor
{
    void DamageCamp(GameContext gameContext);
    IEnumerable<CampElement> GetLastDamagedElements();
}
