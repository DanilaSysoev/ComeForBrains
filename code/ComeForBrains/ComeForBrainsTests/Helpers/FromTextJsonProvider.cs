using ComeForBrains.Core.Building;

namespace ComeForBrainsTests.Helpers;

public class FromTextJsonProvider : IJsonProvider
{
    public FromTextJsonProvider(string json)
    {
        this.json = json;
    }

    public string GetJson()
    {
        return json;
    }

    private readonly string json;
}
