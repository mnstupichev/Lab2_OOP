using InventorySystem.InventoryFolder.Results;
using InventorySystem.Items.BaseItem;

namespace InventorySystem.InventoryFolder.InventoryStates;

public interface IInventoryState
{
    AddItemResult TryAddItem(Inventory inventory, IItem item);
    RemoveResult TryRemoveItem(Inventory inventory, IItem item);
}
