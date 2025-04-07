using System;
using ComeForBrains.Service;

namespace ComeForBrainsTests.Helpers;

public class DummyIdProvider : IUniqueIdProvider
{
    public bool IsUsed(ulong id)
    {
        return id < nextId;
    }

    public ulong NextId()
    {
        return nextId++;
    }

    private ulong nextId = 1;
}
