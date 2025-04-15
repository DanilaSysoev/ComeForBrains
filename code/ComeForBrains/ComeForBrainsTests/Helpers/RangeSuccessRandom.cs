using ComeForBrains.Service;

namespace ComeForBrainsTests.Helpers;

public class RangeSuccessRandom : IRandom
{
    public RangeSuccessRandom(int minSuccess = 0, int maxSuccess = 100)
    {
        MinSuccess = minSuccess;
        MaxSuccess = maxSuccess;
    }

    public int MinSuccess { get; }
    public int MaxSuccess { get; }

    public double NextDouble(double max)
    {
        return 0;
    }

    public double NextDouble(double min, double max)
    {
        return 0;
    }

    public bool Try(double chance)
    {
        return chance >= MinSuccess && chance < MaxSuccess;
    }
}
