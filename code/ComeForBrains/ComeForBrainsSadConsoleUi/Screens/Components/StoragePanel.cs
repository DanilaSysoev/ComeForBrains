
using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Screens.Components.Items;
using ComeForBrainsSadConsoleUi.Service;
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
        CreatePersonPanel();
        CreateMenuPanel();
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
        posX += L["CampElementsButton"].Length + 2 + SpaceBetweenButtons + ButtonXPadding;
        CreateButton((posX, 1), L["FuelsButton"], fuels);
    }


    private int CalcItemsListsWidth()
    {
        return Width * 4 / 10;
    }

    private int CalcDescriptionPanelWidth()
    {
        return Width * 4 / 10;
    }

    private void CreateItemsLists()
    {
        var width = CalcItemsListsWidth();

        meleeWeapons = new MeleeWeaponsListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<MeleeWeapon>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        meleeWeapons.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(meleeWeapons);

        rangedWeapons = new RangedWeaponsListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<RangedWeapon>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        rangedWeapons.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(rangedWeapons);

        armors = new ArmorsListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<Armor>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        armors.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(armors);

        infectionKillers = new InfectionKillersListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<InfectionKiller>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        infectionKillers.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(infectionKillers);

        campElements = new CampElementsListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<CampElement>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        campElements.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(campElements);

        medicines = new MedicinesListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<Medicine>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        medicines.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(medicines);

        provisions = new ProvisionsListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<Provision>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        provisions.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(provisions);

        fuels = new FuelListPanel(
            width,
            Height - ButtonsPanelHeight - MenuPanelHeight,
            new FromStorageItemsProvider<Fuel>()
        ) { Position = (0, ButtonsPanelHeight),
            IsVisible = false,
            IsEnabled = false };
        fuels.ListBox.SelectedItemChanged += (_, _) => SelectItem();
        Children.Add(fuels);
    }

    private void CreateButton(
        Point position,
        string text,
        ItemListPanelBase itemsListPanel
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
        descriptionPanel = new BorderedPanel(
            CalcDescriptionPanelWidth(),
            Height - ButtonsPanelHeight - MenuPanelHeight
        ) { Position = (CalcItemsListsWidth(), ButtonsPanelHeight) };
        Children.Add(descriptionPanel);
    }

    private void Setup()
    {
        currentListPanel = meleeWeapons;
        currentListPanel.IsEnabled = true;
        currentListPanel.IsVisible = true;
    }

    private void SwitchListPanel(
        ItemListPanelBase newListPanel
    ) {
        currentListPanel.IsEnabled = false;
        currentListPanel.IsVisible = false;
        newListPanel.IsEnabled = true;
        newListPanel.IsVisible = true;
        currentListPanel = newListPanel;
        SelectItem();
    }

    private void SelectItem()
    {
        descriptionPanel.Children.Clear();
        if(currentListPanel.ListBox.SelectedItem is null)
            return;
        
        Item? selectedItem = (Item?)currentListPanel.ListBox.SelectedItem;
        if(selectedItem is null)
            return;
        var view = currentListPanel.CreateItemView(selectedItem);
        if(currentListPanel.InteractButton is not null)
            currentListPanel.InteractButton.Click += (_, _) => ActivateRadraw();
        if(currentListPanel.TakeButton is not null)
            currentListPanel.TakeButton.Click += (_, _) => ActivateRadraw();
        if(currentListPanel.PutButton is not null)
            currentListPanel.PutButton.Click += (_, _) => ActivateRadraw();

        view.Position = (2, 1);
        descriptionPanel.Children.Add(view);
    }

    private void ActivateRadraw()
    {
        CreatePersonPanel();
        SelectItem();
    }

    private void CreateMenuPanel()
    {
        ButtonBox button =
            new(L["Back to camp"].Length + 2, 3)
            {
                Position = (2, Height - MenuPanelHeight + 1),
                Text = L["Back to camp"],
            };
        button.Click +=
            (_, _) => GameScreen.SwitchToScreen(new CampScreen());
        controls.Add(button);
    }

    private void CreatePersonPanel()
    {
        if(Children.Contains(personInfoPanel))
            Children.Remove(personInfoPanel);

        var posX = CalcDescriptionPanelWidth() + CalcItemsListsWidth();

        personInfoPanel = new PersonInfoPanel(
            Game.Instance.ScreenCellsX - posX,
            Height - ButtonsPanelHeight - MenuPanelHeight
        ) { Position = (posX, ButtonsPanelHeight) };
        Children.Add(personInfoPanel);
    }


    private MeleeWeaponsListPanel meleeWeapons = null!;
    private RangedWeaponsListPanel rangedWeapons = null!;
    private ArmorsListPanel armors = null!;
    private InfectionKillersListPanel infectionKillers = null!;
    private CampElementsListPanel campElements = null!;
    private MedicinesListPanel medicines = null!;
    private ProvisionsListPanel provisions = null!;
    private FuelListPanel fuels = null!;

    private ItemListPanelBase currentListPanel = null!;
    private BorderedPanel descriptionPanel = null!;
    private ControlHost controls = null!;

    private PersonInfoPanel personInfoPanel = null!;

    private const int ButtonsPanelHeight = 5;
    private const int SpaceBetweenButtons = 1;
    private const int ButtonXPadding = 2;
    private const int MenuPanelHeight = 5;
}
