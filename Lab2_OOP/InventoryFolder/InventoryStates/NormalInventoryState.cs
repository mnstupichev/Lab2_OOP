using Lab2_OOP.InventoryFolder.Results;
using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.InventoryFolder.InventoryStates;

public class NormalInventoryState : IInventoryState
{
    public AddItemResult TryAddItem(Inventory inventory, IItem item)
    {
        var newQuantity = inventory.CurrentQuantity + item.Quantity;
        if (newQuantity > inventory.MaxQuantity)
        {
            return new  AddItemResult.NotEnoughtPlace();
        }
        
        if (newQuantity == inventory.MaxQuantity)
        {
            inventory.AddItem(item);
            inventory.ChangeState(new OverloadedInventoryState());
            return new AddItemResult.AlreadyFull();
        }
        
        inventory.AddItem(item);
        return new AddItemResult.Success();
    }

    public RemoveResult TryRemoveItem(Inventory inventory, IItem item)
    {
        inventory.RemoveItem(item);
        return new RemoveResult.Success();
    }
}
