using Lab2_OOP.InventoryFolder.Results;
using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.InventoryFolder.InventoryStates;

public interface IInventoryState
{
    AddItemResult TryAddItem(Inventory inventory, IItem item);
    RemoveResult TryRemoveItem(Inventory inventory, IItem item);
}
