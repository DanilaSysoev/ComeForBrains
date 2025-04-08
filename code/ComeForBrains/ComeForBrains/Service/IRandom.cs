namespace ComeForBrains.Service;

public interface IRandom
{
    public bool Try(int chance);
    public double NextDouble(double max);
    public double NextDouble(double min, double max);
}
