using ComeForBrains.Localizations;

namespace ComeForBrainsTests.Helpers;

public class DummyLocalization : ILocalization
{
    public string this[string key] => key;
}
