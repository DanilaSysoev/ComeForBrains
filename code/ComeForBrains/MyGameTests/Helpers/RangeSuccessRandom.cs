using ComeForBrains.Service;

namespace MyGameTests.Helpers;

public class RangeSuccessRandom : IRandom
{
    public RangeSuccessRandom(int minSuccess = 0, int maxSuccess = 100)
    {
        MinSuccess = minSuccess;
        MaxSuccess = maxSuccess;
    }

    public int MinSuccess { get; }
    public int MaxSuccess { get; }

    public bool Try(int chance)
    {
        return chance >= MinSuccess && chance < MaxSuccess;
    }
}
