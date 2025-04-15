namespace ComeForBrains.Service;

public interface IRandom
{
    public bool Try(double chance);
    public double NextDouble(double max);
    public double NextDouble(double min, double max);
}
