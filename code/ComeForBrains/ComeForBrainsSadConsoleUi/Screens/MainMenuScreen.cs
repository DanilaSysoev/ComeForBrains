using ComeForBrainsSadConsoleUi.Screens.Components;
using SadConsole.Input;

namespace ComeForBrainsSadConsoleUi.Screens;

public class MainMenuScreen : GameScreen
{
    public MainMenuScreen()
    {
        CreateTitle();
        CreateMenu();
    }


    private void CreateTitle()
    {
        var titleSurface = new ScreenSurface(
            GetTitleWidth(),
            GetTitleHeight()
        );
        titleSurface.Position = new Point(
            (Game.Instance.ScreenCellsX - GetTitleWidth()) / 2, TitleY
        );
        for (int line = 0; line < Title.Length; ++line)
        {
            titleSurface.Print(
                0, line, Title[line], Color.Red
            );
        }
        Children.Add(titleSurface);
    }

    private void CreateMenu()
    {
        var mainMenu = new Menu(
            new Point((Game.Instance.ScreenCellsX - GetMenuWidth()) / 2, GetMenuY()),
            CreateMenuItemsAndActions()
        );
        Children.Add(mainMenu);
    }


    private int GetMenuY()
    {
        return TitleY + GetTitleHeight() + MenuOffsetY;
    }

    private int GetMenuWidth()
    {
        return MenuItems.Max(x => x.Length);
    }

    private List<KeyValuePair<string, EventHandler<MouseScreenObjectState>?>>
    CreateMenuItemsAndActions()
    {
        return new () {
            new (MenuItems[0], (_, _) => ToCampState()),
            new (MenuItems[1], (_, _) =>
                               Game.Instance.MonoGameInstance.Exit()),
        };
    }

    private static void ToCampState()
    {
        Environment.Create();
        Game.Instance.Screen = new CampScreen();
    }

    private int GetTitleHeight()
    {
        return Title.Length;
    }

    private int GetTitleWidth()
    {
        return Title.Max(x => x.Length);
    }

    private const int MenuOffsetY = 10;
    private const int TitleY = 2;

    private readonly string[] Title = L["GameTitle"].Split('\n');

    private readonly string[] MenuItems = [
        L["StartGame"],
        L["QuitGame"]
    ];
}
