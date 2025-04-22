namespace ComeForBrains.Core.Building;

public class FromFileJsonProvider : IJsonProvider
{
    public FromFileJsonProvider(string path)
    {
        this.path = path;
    }
    
    public string GetJson()
    {
        return File.ReadAllText(path);
    }

    private readonly string path;
}
