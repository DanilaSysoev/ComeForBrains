using ComeForBrains.Core.Items;

namespace ComeForBrains.Core.Characters;

public class Inventory
{
    public double Weight { get; private set; } = 0;

    public int Count => items.Count;
    public IEnumerable<Item> AllItems => items;
    public IEnumerable<T> GetItems<T>() where T : Item
    {
        if(!itemsByType.ContainsKey(typeof(T)))
            return new List<T>();

        List<T> result = new();
        foreach(var i in itemsByType[typeof(T)])
            result.Add((T)i);
        return result;
    }
    public int GetItemCount<T>() where T : Item
    {
        if(!itemsByType.ContainsKey(typeof(T)))
            return 0;

        return itemsByType[typeof(T)].Count;
    }
    public void AddItem(Item item)
    {
        if(itemsByType.ContainsKey(item.GetType()))
            itemsByType[item.GetType()].Add(item);
        else
            itemsByType.Add(item.GetType(), new List<Item>() { item });
        items.Add(item);
        Weight += item.Weight;
    }
    public void RemoveItem(Item item)
    {
        if(items.Remove(item))
        {
            Weight -= item.Weight;
            itemsByType[item.GetType()].Remove(item);
        }
    }

    private readonly List<Item> items = new();
    private readonly Dictionary<Type, List<Item>> itemsByType = new();
}
