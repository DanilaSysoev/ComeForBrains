namespace ComeForBrains.Engine.Drawing;

public abstract class DrawProcessor : IDrawProcessor
{
    public void Draw(IGameContext gameContext)
    {
        PreDraw(gameContext);
        DrawActions(gameContext);
        PostDraw(gameContext);
    }

    public abstract void PreDraw(IGameContext gameContext);
    internal abstract void DrawActions(IGameContext gameContext);
    public abstract void PostDraw(IGameContext gameContext);
}
