using Lab2_OOP.InventoryFolder.Results;
using Lab2_OOP.Items.BaseItem;

namespace Lab2_OOP.InventoryFolder.InventoryStates;

public class OverloadedInventoryState : IInventoryState
{
    public AddItemResult TryAddItem(Inventory inventory, IItem item)
    {
        return new AddItemResult.AlreadyFull();
    }

    public RemoveResult TryRemoveItem(Inventory inventory, IItem item)
    {
        inventory.RemoveItem(item);
        inventory.ChangeState(new NormalInventoryState());
        return new RemoveResult.Success();
    }
}
