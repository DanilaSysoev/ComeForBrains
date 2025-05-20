using ComeForBrains.Core.Items;
using ComeForBrainsSadConsoleUi.Service;
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Screens.Components.Items;

public abstract class ItemsListPanel<TItem> : ItemListPanelBase
    where TItem : Item
{
    protected ItemsListPanel(
        int width,
        int height,
        string title,
        IItemsProvider itemsProvider
    )
        : base(width, height, title, itemsProvider)
    {
    }

    public override ScreenSurface CreateItemView(Item item)
    {
        return CreateItemView((TItem)item);
    }
    
    public ScreenSurface CreateItemView(TItem item)
    {
        lines = CreateLines(item);

        ScreenSurface result = new(CalcWidth(item), CalcHeight());

        CreateButtons(item, result);

        for (int i = 0; i < lines.Count; ++i)
            result.Print(0, i, lines[i]);

        return result;
    }

    private void CreateButtons(TItem item, ScreenSurface result)
    {
        ControlHost controls = new ControlHost();
        result.SadComponents.Add(controls);

        CreateInteractButton(item, controls);
        CreateTakeButton(item, controls);
        CreatePutButton(item, controls);
    }

    private void CreatePutButton(TItem item, ControlHost controls)
    {
        if (CanTake(item))
            return;

        PutButton =
            new ButtonBox(L["Put"].Length + 2, ButtonHeight);
        PutButton.Position = (
            0, CalcHeight() - ButtonHeight
        );
        PutButton.Click += (_, _) => Put(item);
        PutButton.Text = L["Put"];
        controls.Add(PutButton);
    }

    protected virtual bool CanTake(TItem item)
    {
        return !Environment.Instance.Context.Person.Inventory.Contains(item);
    }

    protected virtual void Put(TItem item)
    {
        if (!CanTake(item))
            Environment.Instance.Context.Person.Inventory.RemoveItem(item);
        ListBox.IsDirty = true;
    }

    private void CreateTakeButton(TItem item, ControlHost controls)
    {
        if (!CanTake(item))
            return;
        
        TakeButton =
            new ButtonBox(L["Take"].Length + 2, ButtonHeight);
        TakeButton.Position = (
            0,
            CalcHeight() - ButtonHeight
        );
        TakeButton.Click += (_, _) => Take(item);
        TakeButton.Text = L["Take"];
        controls.Add(TakeButton);
    }

    private void Take(TItem item)
    {
        if (CanTake(item))
            Environment.Instance.Context.Person.Inventory.AddItem(item);
        ListBox.IsDirty = true;
    }

    private void CreateInteractButton(
        TItem item, ControlHost controls
    )
    {
        string interactText = GetInteractText(item);
        InteractButton =
            new ButtonBox(interactText.Length + 2, ButtonHeight);
        InteractButton.Position = (0, CalcHeight() - 2 * ButtonHeight);
        InteractButton.Click += (_, _) => InteractWithItem(item);
        InteractButton.Text = interactText;
        controls.Add(InteractButton);
    }

    private void InteractWithItem(TItem item)
    {
        var selectedItem = ListBox.SelectedItem;
        item.Interact(Environment.Instance.Context);
        var newItems = ItemsProvider.GetItems();
        if(selectedItem is not null &&
           !newItems.Contains(selectedItem))
        {
            Items.Remove((Item)selectedItem);
            ListBox.SelectedItem = null;
            ListBox.Items.Remove(selectedItem);
        }
        ListBox.IsDirty = true;
    }

    protected virtual string GetInteractText(TItem item)
    {
        return "Interact";
    }

    protected abstract List<string> CreateLines(TItem item);

    virtual protected int CalcHeight()
    {
        return lines.Count + 2 * ButtonHeight;
    }

    virtual protected int CalcWidth(TItem item)
    {
        if (lines.Count == 0)
            return GetInteractText(item).Length + 2;

        return Math.Max(
            lines.Select(line => line.Length).Max(),
            GetButtonsWidth(item)
        );
    }

    private int GetButtonsWidth(TItem item)
    {
        return Math.Max(
            GetInteractText(item).Length,
            Math.Max(
                L["Take"].Length,
                L["Put"].Length
            )
        ) + 2;
    }

    private List<string> lines = [];
    protected const int ButtonHeight = 3;
}
