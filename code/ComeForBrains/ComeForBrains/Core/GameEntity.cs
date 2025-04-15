using ComeForBrains.Localizations;

namespace ComeForBrains.Core;

public class GameEntity
{
    protected GameEntity() {}

    protected readonly static ILocalization L = Localization.GetInstance();
}
