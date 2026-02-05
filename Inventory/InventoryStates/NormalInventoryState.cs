using InventorySystem.Interfaces;

namespace InventorySystem.States;

public class NormalInventoryState : IInventoryState
{
    public bool CanAddItem(IItem item, int currentQuantity, int maxQuantity)
    {
        return currentQuantity + item.Quantity <= maxQuantity;
    }

    public bool CanRemoveItem()
    {
        return true;
    }

    public IInventoryState? Transition(int currentQuantity, int maxQuantity)
    {
        if (currentQuantity > maxQuantity)
        {
            return new OverloadedInventoryState();
        }
        return null;
    }
}
