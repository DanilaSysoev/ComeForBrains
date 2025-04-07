namespace ComeForBrains.Service;

public interface IUniqueIdProvider
{
    ulong NextId();
    bool IsUsed(ulong id);
}
