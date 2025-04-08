using System;

namespace ComeForBrains.Service;

public class SystemRandom : IRandom
{
    public SystemRandom()
    {
        random = new();
    }
    public SystemRandom(int seed)
    {
        random = new(seed);
    }

    public bool Try(int chance)
    {
        return random.Next(100) < chance;
    }

    public double NextDouble(double max)
    {
        return random.NextDouble() * max;
    }

    public double NextDouble(double min, double max)
    {
        return (max - min) * random.NextDouble() + min;
    }

    private readonly Random random;
}
