using ComeForBrains.Core;

namespace ComeForBrains.Engine;

public interface IUpdateProcessor
{
    void Update(IGameContext gameContext, IGame game);
}
