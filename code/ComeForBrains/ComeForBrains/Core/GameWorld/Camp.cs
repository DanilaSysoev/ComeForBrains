using ComeForBrains.Core.Building.GameWorld;
using ComeForBrains.Core.Items;
using ComeForBrains.Core.Mechanics.Base;

namespace ComeForBrains.Core.GameWorld;


public class Camp
{
    public double Fortification => fortification;
    public double Comfort => comfort;    
    public IEnumerable<CampElement> CampElements => allElements;
    public IEnumerable<CampElement> ExternalCampElements => externalElements;
    public IEnumerable<CampElement> InternalCampElements => internalElements;
    
    public GameContext GameContext { get; internal set; } = null!;
    public ICampDestructor Destructor => destructor;

    public Camp(ICampBuilder builder)
    {
        destructor = builder.BuildDestructor();
    }

    public void AddToStorage(Item item)
    {
        storage.Add(item);
    }
    public void RemoveFromStorage(Item item)
    {
        storage.Remove(item);
    }

    public void SetupCampElement(CampElement campElement)
    {
        allElements.Add(campElement);
        if(campElement.ElementType == CampElementType.Internal)
            internalElements.Add(campElement);
        else
            externalElements.Add(campElement);
        CalculateFortificationAndComfort();
    }
    public void RemoveCampElement(CampElement campElement)
    {
        allElements.Remove(campElement);
        if (campElement.ElementType == CampElementType.Internal)
            internalElements.Remove(campElement);
        else
            externalElements.Remove(campElement);
        CalculateFortificationAndComfort();
    }
    public void DamageCampAtNight()
    {
        destructor.DamageCamp(GameContext);
    }


    private void CalculateFortificationAndComfort()
    {
        fortification = 0;
        comfort = 0;
        UpdateFortificationAndComfort(internalElements);
        UpdateFortificationAndComfort(externalElements);
    }
    private void UpdateFortificationAndComfort(
        IEnumerable<CampElement> elementConditions
    )
    {
        foreach (var elementCondition in elementConditions)
        {
            fortification += elementCondition.Fortification;
            comfort += elementCondition.Comfort;
        }
    }

    private double fortification = 0;
    private double comfort = 0;

    private readonly ICampDestructor destructor;

    private readonly List<CampElement> allElements = new();
    private readonly List<CampElement> internalElements = new();
    private readonly List<CampElement> externalElements = new();
    private readonly List<Item> storage = new();
}
