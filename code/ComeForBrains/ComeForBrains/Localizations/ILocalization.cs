namespace ComeForBrains.Localizations;

public interface ILocalization
{
    string this[string key] { get; }
}
