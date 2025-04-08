using ComeForBrains.Service;

namespace ComeForBrainsTests.Helpers;

public class AlwaysPredeclaredRandom : IRandom
{
    public AlwaysPredeclaredRandom(double value)
    {
        this.value = value;
    }

    public double NextDouble(double max)
    {
        return max * value;
    }

    public double NextDouble(double min, double max)
    {
        return (max - min) * value + min;
    }

    public bool Try(int chance)
    {
        return false;
    }

    private readonly double value;
}
