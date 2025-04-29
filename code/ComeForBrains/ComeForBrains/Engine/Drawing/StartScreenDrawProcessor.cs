namespace ComeForBrains.Engine.Drawing;

public abstract class StartScreenDrawProcessor : DrawProcessor
{
    internal override void DrawActions(IGameContext gameContext)
    {
        DrawTitle(gameContext);
        DrawStartGameSelector(gameContext);
        DrawExitGameSelector(gameContext);
        DrawDecorations(gameContext);
    }

    public abstract void DrawTitle(IGameContext gameContext);
    public abstract void DrawDecorations(IGameContext gameContext);
    public abstract void DrawStartGameSelector(IGameContext gameContext);
    public abstract void DrawExitGameSelector(IGameContext gameContext);
}
