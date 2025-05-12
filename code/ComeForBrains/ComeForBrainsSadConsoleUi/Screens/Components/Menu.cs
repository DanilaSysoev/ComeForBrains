using SadConsole.Input;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class Menu : ScreenSurface
{
    public int BorderWidth { get; set; }
    public int BorderHeight { get; set; }

    public Menu(
        Point position,
        IList<KeyValuePair<string,
                           EventHandler<MouseScreenObjectState>?>> items,
        int borderWidth = 0,
        int borderHeight = 0
    ) : base(items.Select(x => x.Key.Length).Max() + 2 * borderWidth,
             items.Count + 2 * borderHeight)
    {
        BorderWidth = borderWidth;
        BorderHeight = borderHeight;
        Position = position;

        for (var i = 0; i < items.Count; i++)
        {
            var menuItem = new MenuItem(items[i].Key, Width);
            menuItem.MouseButtonClicked += items[i].Value;
            menuItem.Position = new Point(0, i);
            menuItems.Add(menuItem);
            Children.Add(menuItem);
        }
    }

    private readonly List<MenuItem> menuItems = new();
}
