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

    private readonly Random random;
}
