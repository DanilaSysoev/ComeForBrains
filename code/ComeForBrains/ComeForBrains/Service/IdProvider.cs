namespace ComeForBrains.Service;

public static class IdProvider
{
    private static IUniqueIdProvider? idProvider;

    public static void Initialize(IUniqueIdProvider provider)
    {
        if(idProvider is not null)
        {
            throw new InvalidOperationException(
                "Id provider already initialized"
            );
        }
        idProvider = provider;
    }

    public static void Clear()
    {
        idProvider = null;
    }

    public static ulong NextId()
    {
        if(idProvider is null)
        {
            throw new InvalidOperationException(
                "Id provider is not initialized"
            );
        }
        return idProvider.NextId();
    }
    public static bool IsUsed(ulong id)
    {
        if(idProvider is null)
        {
            throw new InvalidOperationException(
                "Id provider is not initialized"
            );
        }
        return idProvider.IsUsed(id);
    }
}
