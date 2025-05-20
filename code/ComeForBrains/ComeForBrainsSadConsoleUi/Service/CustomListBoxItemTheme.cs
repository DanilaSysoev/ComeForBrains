using ComeForBrains.Core.Items;
using SadConsole.UI.Controls;

namespace ComeForBrainsSadConsoleUi.Service;

public class CustomListBoxItemTheme : ListBoxItemTheme
{
    public override void Draw(ControlBase control, Rectangle area, object item, ControlStates itemState)
    {
        if(item is Item gameItem)
        {
            if(Environment.Instance.Context.Person.Inventory.Contains(gameItem))
                item = SadUiGameSettings.InventoryMarker + gameItem.ToString();
            else
                item = gameItem.ToString();
        }
        base.Draw(control, area, item, itemState);
    }
}
