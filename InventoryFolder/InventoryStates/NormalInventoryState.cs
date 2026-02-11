using InventorySystem.InventoryFolder.Results;
using InventorySystem.Items.BaseItem;

namespace InventorySystem.InventoryFolder.InventoryStates;

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
            inventory.ChangeState(new OverloadedInventoryState());
            return new AddItemResult.AlreadyFull();
        }
        
        inventory.AddItem(item);
        return new AddItemResult.Success();
    }

    public RemoveResult TryRemoveItem(Inventory inventory, IItem item)
    {
        return new RemoveResult.Success();
    }
}
