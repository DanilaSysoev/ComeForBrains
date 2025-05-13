
using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Screens.Components.Items;
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class StoragePanel : BasePanel
{
    public StoragePanel(int width, int height)
        : base(width, height)
    {
        CreateItemsLists();
        CreateSwitchButtons();
        CreateDescriptionPanel();
        Setup();
    }

    private void CreateSwitchButtons()
    {
        controls = new();
        SadComponents.Add(controls);
        
        int posX = 1;
        CreateButton((posX, 1), L["MeleeWeaponsButton"], meleeWeapons);
        posX += L["MeleeWeaponsButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["RangedWeaponsButton"], rangedWeapons);
        posX += L["RangedWeaponsButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["ArmorsButton"], armors);
        posX += L["ArmorsButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["MedicinesButton"], medicines);
        posX += L["MedicinesButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["InfectionKillersButton"], infectionKillers);
        posX += L["InfectionKillersButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["ProvisionsButton"], provisions);
        posX += L["ProvisionsButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["CampElementsButton"], campElements);

        DrawButtonsBorder();
    }

    private void CreateItemsLists()
    {
        meleeWeapons = new MeleeWeaponsListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<MeleeWeapon>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(meleeWeapons);

        rangedWeapons = new RangedWeaponsListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<RangedWeapon>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(rangedWeapons);

        armors = new ArmorsListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<Armor>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(armors);

        infectionKillers = new InfectionKillersListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<InfectionKiller>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(infectionKillers);

        campElements = new CampElementsListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<CampElement>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(campElements);

        medicines = new MedicinesListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<Medicine>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(medicines);

        provisions = new ProvisionsListPanel(
            Width / 2,
            Height - ButtonsPanelHeight,
            Environment.Instance.Context.Camp.GetFromStorage<Provision>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        Children.Add(provisions);
    }

    private void CreateButton(
        Point position,
        string text,
        ScreenSurface itemsListPanel
    )
    {
        ButtonBox button =
            new(text.Length + 2 + ButtonXPadding, ButtonsPanelHeight - 2)
            {
                Position = position,
                Text = text,
            };
        button.Click +=
            (_, _) => SwitchListPanel(itemsListPanel);
        controls.Add(button);
    }

    private void CreateDescriptionPanel()
    {
        descriptionPanel = new ScreenSurface(
            Width / 2, Height - ButtonsPanelHeight
        ) { Position = (Width / 2, ButtonsPanelHeight) };
    }

    private void Setup()
    {
        currentListPanel = meleeWeapons;
        currentListPanel.IsEnabled = true;
        currentListPanel.IsVisible = true;
    }

    private void SwitchListPanel(
        ScreenSurface newListPanel
    ) {
        currentListPanel.IsEnabled = false;
        currentListPanel.IsVisible = false;
        newListPanel.IsEnabled = true;
        newListPanel.IsVisible = true;
        currentListPanel = newListPanel;
    }

    private void DrawButtonsBorder()
    {
        Surface.DrawBox(
            new Rectangle(0, 0, Width, ButtonsPanelHeight),
            ShapeParameters.CreateStyledBox(
                ICellSurface.ConnectedLineThin,
                new ColoredGlyph(
                    Surface.DefaultForeground,
                    Surface.DefaultBackground
                )
            )
        );
    }

    private MeleeWeaponsListPanel meleeWeapons = null!;
    private RangedWeaponsListPanel rangedWeapons = null!;
    private ArmorsListPanel armors = null!;
    private InfectionKillersListPanel infectionKillers = null!;
    private CampElementsListPanel campElements = null!;
    private MedicinesListPanel medicines = null!;
    private ProvisionsListPanel provisions = null!;

    private ScreenSurface currentListPanel = null!;
    private ScreenObject descriptionPanel = null!;
    private ControlHost controls = null!;

    private const int ButtonsPanelHeight = 5;
    private const int SpaceBetweenButtons = 1;
    private const int ButtonXPadding = 2;
}
