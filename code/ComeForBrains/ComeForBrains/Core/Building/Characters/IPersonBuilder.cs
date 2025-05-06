using ComeForBrains.Core.Characters;

namespace ComeForBrains.Core.Building.Characters;

public interface IPersonBuilder
{
    public string GetName();
    
    PersonAttribute GetEnergy();
    PersonAttribute GetHealth();
    PersonAttribute GetSatiety();
    PersonAttribute GetThirst();

    double GetBaseInfectionChance();    
    double GetStrength();
    double GetDexterity();
    double GetDistanceAccuracy();
    double GetMeleeFight();
    double GetSpeed();
}
