namespace ComeForBrains.GameStates;

public class GameState : ScreenObject
{
    public virtual void In() {}
    public virtual void Out() {}

    public void SwitchTo(GameState nextState)
    {
        Out();
        Game.Instance.Screen = nextState;
        nextState.In();
    }
}
