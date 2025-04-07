using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building.Characters;

public interface IPersonBuilder
{
    public string GetName();
    
    PersonAttribute GetEnergy();
    PersonAttribute GetHealth();
    PersonAttribute GetSatiety();
    PersonAttribute GetThirst();

    int GetBaseInfectionChance();
    
    int GetStrength();
    int GetDexterity();
    int GetDistanceAccuracy();
    int GetMeleeFight();
    int GetSpeed();
}
