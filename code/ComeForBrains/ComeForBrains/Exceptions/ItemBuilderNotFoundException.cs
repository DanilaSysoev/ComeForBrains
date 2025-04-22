namespace ComeForBrains.Exceptions;

public class ItemBuilderNotFoundException : Exception
{
    public ItemBuilderNotFoundException(string itemName) 
        : base($"Item builder for item named '{itemName}' not found") {}
}
