namespace ComeForBrains.Engine;

public class Game : IGame
{
    public Game(
        IDrawProcessor drawProcessor,
        ICommandProvider commandProvider,
        IUpdateProcessor updateProcessor,
        IGameContext context
    )
    {
        this.drawProcessor = drawProcessor;
        this.commandProvider = commandProvider;
        this.updateProcessor = updateProcessor;

        this.context = context;
    }

    public void Start()
    {
        while (!context.IsGameEnded)
        {
            drawProcessor.Draw(context);
            var command = commandProvider.GetNextCommand(context);
            command.Execute(context);
            updateProcessor.Update(context, this);
        }
    }

    public void SetState(
        IDrawProcessor drawProcessor,
        ICommandProvider commandProvider,
        IUpdateProcessor updateProcessor
    )
    {
        this.drawProcessor = drawProcessor;
        this.commandProvider = commandProvider;
        this.updateProcessor = updateProcessor;
    }

    private IDrawProcessor drawProcessor;
    private ICommandProvider commandProvider;
    private IUpdateProcessor updateProcessor;
    private readonly IGameContext context;
}
