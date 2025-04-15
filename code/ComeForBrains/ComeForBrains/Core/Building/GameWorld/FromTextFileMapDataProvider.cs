namespace ComeForBrains.Core.Building.GameWorld;

public class FromTextFileMapDataProvider : IMapDataProvider
{
    public FromTextFileMapDataProvider(string path)
    {
        this.path = path;
    }

    public string[] GetMapData()
    {
        return File.ReadAllLines(path);
    }

    private readonly string path;
}
