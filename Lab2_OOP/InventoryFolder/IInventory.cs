using Lab2_OOP.InventoryFolder.Results;
using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.InventoryFolder;

public interface IInventory
{
    int MaxQuantity { get; }
    
    int CurrentQuantity { get; }
    
    IReadOnlyList<IItem> Items { get; }

    AddItemResult TryAddItem(IItem item);

    RemoveResult TryRemoveItem(IItem item);


}