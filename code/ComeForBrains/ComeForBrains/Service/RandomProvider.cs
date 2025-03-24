namespace ComeForBrains.Service;

public static class RandomProvider
{
    public static void Initialize(IRandom random)
    {
        RandomProvider.random = random;
    }

    public static IRandom Instance
    {
        get
        {
            if (random == null)
                throw new InvalidOperationException("You must initialize the RandomProvider.");
            return random;
        }
    }

    private static IRandom? random;
}
