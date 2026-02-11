using InventorySystem.InventoryFolder.Results;
using InventorySystem.Items.BaseItem;

namespace InventorySystem.InventoryFolder;

public interface IInventory
{
    int MaxQuantity { get; }
    
    int CurrentQuantity { get; }
    
    IReadOnlyList<IItem> Items { get; }

    AddItemResult TryAddItem(IItem item);

    RemoveResult TryRemoveItem(IItem item);


}