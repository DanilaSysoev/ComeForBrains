using System.Text.Json;

namespace ComeForBrains.Service;

public class IncrementalIdProvider : IUniqueIdProvider
{
    public IncrementalIdProvider(
        string storagePath = "Data/IdStorage.json"
    )
    {
        this.storagePath = storagePath;
        var storage = JsonSerializer.Deserialize<Dictionary<string, ulong>>(
            File.ReadAllText(storagePath)
        );
        if (storage is null)
            throw new InvalidOperationException("Invalid storage file");
        
        this.nextId = storage["nextId"];
    }

    public bool IsUsed(ulong id)
    {
        return id < nextId;
    }

    public ulong NextId()
    {
        var result = nextId++;
        try
        {
            File.WriteAllText(
                storagePath,
                $"{{\n    \"nextId\": {nextId}\n}}"
            );
        } catch (Exception ex)
        {
            Console.WriteLine(
                "Ошибка при записи id storage: " + ex.ToString()
            );
        }
        return result;
    }


    private ulong nextId;
    private readonly string storagePath;
}
