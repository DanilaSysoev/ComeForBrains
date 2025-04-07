using ComeForBrains.Service;
using ComeForBrainsTests.Helpers;

namespace ComeForBrainsTests;

public class Tests
{
    [OneTimeSetUp]
    public void GlobalInitialize()
    {
        IdProvider.Clear();
        IdProvider.Initialize(new DummyIdProvider());
    }
}
